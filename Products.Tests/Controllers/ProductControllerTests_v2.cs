using Eshop.ServiceDefaults.RabbitMQ;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Product.API.Controllers;
using Product.Domain.Enums;
using Product.Domain.Interfaces.v2;
using Product.Domain.Models;
using Products.Tests.Helpers;
using RabbitMQ.Client;
using System.Text.Json;
using IModel = RabbitMQ.Client.IModel;

namespace Products.Tests.Controllers
{
    public class ProductController_v2_Tests
    {
        private readonly Mock<ILogger<ProductController_v2>> _loggerMock;
        private readonly Mock<IProductCacheService_v2> _productServiceMock;
        private readonly Mock<IConnection> _connectionMock;
        private readonly Mock<IModel> _channelMock;
        private readonly ProductController_v2 _controller;


        public ProductController_v2_Tests()
        {
            _loggerMock = new Mock<ILogger<ProductController_v2>>();
            _productServiceMock = new Mock<IProductCacheService_v2>();
            _connectionMock = new Mock<IConnection>();
            _channelMock = new Mock<IModel>();
            _connectionMock.Setup(c => c.CreateModel()).Returns(_channelMock.Object);

            _controller = new ProductController_v2(
                _loggerMock.Object,
                _productServiceMock.Object,
                _connectionMock.Object
            );
        }




        [Fact]
        public async Task GetAllProducts_Ok_WithProducts()
        {
            var products = ProductMockupHelper.Get_10_Products().OrderBy(x => x.ProductName).ToList();

            _productServiceMock.Setup(s => s.GetAllProducts(1, 10, ProductOrderEnum.ProdAsc)).ReturnsAsync(products);

            var result = await _controller.GetAllProducts(1, 10, ProductOrderEnum.ProdAsc);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(products, okResult.Value);
        }

        [Fact]
        public async Task GetAllProducts_Ok_WithProducts_Less()
        {
            var products = ProductMockupHelper.Get_10_Products().OrderBy(x => x.ProductName).ToList();

            _productServiceMock.Setup(s => s.GetAllProducts(1, 3, ProductOrderEnum.ProdAsc)).ReturnsAsync(products.Take(3));

            var result = await _controller.GetAllProducts(1, 3, ProductOrderEnum.ProdAsc);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(products.Take(3), okResult.Value);
        }


        [Theory]
        [InlineData(0, 10, "Current page cannot be lower than 1")]
        [InlineData(1, 0, "Page size cannot be lower than 1")]
        [InlineData(1, 101, "Page size cannot be higher than 100")]
        public async Task GetAllProducts_InvalidParams_BadRequest(int currentPage, int pageSize, string expectedMessage)
        {
            var result = await _controller.GetAllProducts(currentPage, pageSize);

            var badRequest = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal(expectedMessage, badRequest.Value);
        }


        [Fact]
        public async Task GetProduct_ProductExists_Ok()
        {
            var product = ProductMockupHelper.Get_10_Products().First();

            _productServiceMock.Setup(s => s.GetProduct(1)).ReturnsAsync(product);

            var result = await _controller.GetProduct(1);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(product, okResult.Value);
        }

        [Fact]
        public async Task GetProduct_ProductNotFound_NotFound()
        {
            _productServiceMock.Setup(s => s.GetProduct(1)).ReturnsAsync((Product.Domain.Models.Product)null);

            var result = await _controller.GetProduct(1);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task CreateProduct_NullProduct_ReturnsBadRequest()
        {
            var result = await _controller.CreateProduct(null);

            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Product cannot be null", badRequest.Value);
        }

        [Fact]
        public async Task CreateProduct_ProductCodeExists_BadRequest()
        {
            var createProduct = CreateProductMock.GetCreateProductMock();

            _productServiceMock.Setup(s => s.ProductExistByProductCode(createProduct.ProductCode)).ReturnsAsync(true);

            var result = await _controller.CreateProduct(createProduct);

            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Product with this product code already exists.", badRequest.Value);
        }

        [Fact]
        public async Task CreateProduct_ValidProduct_Created()
        {
            var createProduct = CreateProductMock.GetCreateProductMock();

            _productServiceMock.Setup(s => s.ProductExistByProductCode(createProduct.ProductCode)).ReturnsAsync(false);
            _productServiceMock.Setup(s => s.CreateProduct(createProduct)).Returns(Task.FromResult(true));

            var result = await _controller.CreateProduct(createProduct);

            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public async Task CreateProduct_ValidProduct_EmptyProductCode_Created()
        {
            var createProduct = CreateProductMock.GetCreateProductMock_Base();

            _productServiceMock.Setup(s => s.ProductExistByProductCode(null)).ReturnsAsync(false);
            _productServiceMock.Setup(s => s.CreateProduct(createProduct)).Returns(Task.FromResult(true));

            var result = await _controller.CreateProduct(createProduct);

            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public async Task UpdateStock_NullUpdateStock_BadRequest()
        {
            var result = await _controller.UpdateStock(null);

            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Object cannot be null", badRequest.Value);
        }

        [Fact]
        public async Task UpdateStock_ProductIdLessThanZero_ReturnsBadRequest()
        {
            var updateStock = new UpdateStock { ProductId = -1, StockChange = 1 };

            var result = await _controller.UpdateStock(updateStock);

            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Product id cannot be lower than 0", badRequest.Value);
        }

        [Fact]
        public async Task UpdateStock_ProductNotFound_BadRequest()
        {
            var updateStock = new UpdateStock { ProductId = 1, StockChange = 1 };
            _productServiceMock.Setup(s => s.ProductExistById(1)).ReturnsAsync(false);

            var result = await _controller.UpdateStock(updateStock);

            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Product not found", badRequest.Value);
        }

        [Fact]
        public async Task UpdateStock_ValidRequest_PublishesToQueue_DifferentQueue()
        {
            var updateStock = new UpdateStock { ProductId = 1, StockChange = 1 };
            byte[] test = JsonSerializer.SerializeToUtf8Bytes(updateStock);

            _productServiceMock.Setup(s => s.ProductExistById(1)).ReturnsAsync(true);

            var result = await _controller.UpdateStock(updateStock);

            _channelMock.Verify(c => c.QueueDeclare("", true, false, true, null), Times.Never);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task UpdateStock_ValidRequest_PublishesToQueue_Ok()
        {
            var updateStock = new UpdateStock { ProductId = 1, StockChange = 1 };
            var expectedBody = JsonSerializer.SerializeToUtf8Bytes(updateStock);


            _productServiceMock.Setup(s => s.ProductExistById(1)).ReturnsAsync(true);
            
            var result = await _controller.UpdateStock(updateStock);

            _channelMock.Verify(c => c.QueueDeclare(ProductQueues.UpdateStock, true, false, true, null), Times.Once);

            _channelMock.Verify(c => c.BasicPublish("", ProductQueues.UpdateStock, false, null, It.Is<ReadOnlyMemory<byte>>(b => b.ToArray().SequenceEqual(expectedBody))), Times.Once);

            var okResult = Assert.IsType<OkObjectResult>(result);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task UpdateStock_ValidRequest_PublishesToQueue_DifferentData()
        {
            var updateStock = new UpdateStock { ProductId = 1, StockChange = 1 };
            var expectedBody = JsonSerializer.SerializeToUtf8Bytes(updateStock);

            updateStock.StockChange = 2;


            _productServiceMock.Setup(s => s.ProductExistById(1)).ReturnsAsync(true);

            var result = await _controller.UpdateStock(updateStock);

            _channelMock.Verify(c => c.QueueDeclare(ProductQueues.UpdateStock, true, false, true, null), Times.Once);

            _channelMock.Verify(c => c.BasicPublish("", ProductQueues.UpdateStock, false, null, It.Is<ReadOnlyMemory<byte>>(b => !b.ToArray().SequenceEqual(expectedBody))), Times.Once);

            var okResult = Assert.IsType<OkObjectResult>(result);
        }



    }
}
