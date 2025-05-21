using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Product.API.Controllers;
using Product.Domain.Interfaces.v1;
using Product.Domain.Models;
using Products.Tests.Helpers;

namespace Products.Tests.Controllers
{
    public class ProductControllerTests
    {
        private readonly Mock<ILogger<ProductController>> _loggerMock;
        private readonly Mock<IProductCacheService> _serviceMock;
        private readonly ProductController _controller;

        public ProductControllerTests()
        {
            _loggerMock = new Mock<ILogger<ProductController>>();
            _serviceMock = new Mock<IProductCacheService>();
            _controller = new ProductController(_loggerMock.Object, _serviceMock.Object);
        }

        [Fact]
        public async Task GetAllProducts_OkWithProducts()
        {
            var products = ProductMockupHelper.Get_10_Products().ToList();

            _serviceMock.Setup(s => s.GetAllProducts()).ReturnsAsync(products);

            var result = await _controller.GetAllProducts();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(products, okResult.Value);
        }

        [Fact]
        public async Task GetProduct_ProductExists_Ok()
        {
            var product = ProductMockupHelper.Get_10_Products().First();

            _serviceMock.Setup(s => s.GetProduct(1)).ReturnsAsync(product);

            var result = await _controller.GetProduct(1);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(product, okResult.Value);
        }

        [Fact]
        public async Task GetProduct_ProductDoesNotExist_NotFound()
        {
            var product = ProductMockupHelper.Get_10_Products().First();

            _serviceMock.Setup(s => s.GetProduct(1)).ReturnsAsync(product);
            _serviceMock.Setup(s => s.GetProduct(2)).ReturnsAsync((Product.Domain.Models.Product?)null);

            var result = await _controller.GetProduct(1);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(product, okResult.Value);

            result = await _controller.GetProduct(2);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task CreateProduct_NullProduct_BadRequest()
        {
            var result = await _controller.CreateProduct(null);

            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Product cannot be null", badRequest.Value);
        }

        [Fact]
        public async Task CreateProduct_ProductCodeExists_BadRequest()
        {
            var createProduct = CreateProductMock.GetCreateProductMock();

            _serviceMock.Setup(s => s.ProductExistByProductCode(createProduct.ProductCode)).ReturnsAsync(true);

            var result = await _controller.CreateProduct(createProduct);

            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Product with this product code already exists.", badRequest.Value);
        }


        [Fact]
        public async Task CreateProduct_ValidProduct_EmptyBarcode_Created()
        {
            var createProduct = CreateProductMock.GetCreateProductMock();
            createProduct.ProductCode = string.Empty;

            _serviceMock.Setup(s => s.ProductExistByProductCode("")).ReturnsAsync(true);
            _serviceMock.Setup(s => s.CreateProduct(createProduct)).Returns(Task.FromResult(true));

            var result = await _controller.CreateProduct(createProduct);

            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public async Task CreateProduct_ValidProduct_EmptyBarcode2_Created()
        {
            var createProduct = CreateProductMock.GetCreateProductMock_Base();

            _serviceMock.Setup(s => s.ProductExistByProductCode("")).ReturnsAsync(true);
            _serviceMock.Setup(s => s.CreateProduct(createProduct)).Returns(Task.FromResult(true));

            var result = await _controller.CreateProduct(createProduct);

            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public async Task CreateProduct_ValidProduct_Created()
        {
            var createProduct = CreateProductMock.GetCreateProductMock();

            _serviceMock.Setup(s => s.ProductExistByProductCode(createProduct.ProductCode)).ReturnsAsync(false);
            _serviceMock.Setup(s => s.CreateProduct(createProduct)).Returns(Task.FromResult(true));

            var result = await _controller.CreateProduct(createProduct);

            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public async Task UpdateStock_NullUpdateStock_sBadRequest()
        {
            var result = await _controller.UpdateStock(null);

            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Object cannot be null", badRequest.Value);
        }

        [Fact]
        public async Task UpdateStock_NegativeProductId_BadRequest()
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
            _serviceMock.Setup(s => s.ProductExistById(1)).ReturnsAsync(false);

            var result = await _controller.UpdateStock(updateStock);

            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Product not found", badRequest.Value);
        }

        [Fact]
        public async Task UpdateStock_StockBelowZero_BadRequest()
        {
            var updateStock = new UpdateStock { ProductId = 1, StockChange = -10 };
            _serviceMock.Setup(s => s.ProductExistById(1)).ReturnsAsync(true);
            _serviceMock.Setup(s => s.UpdateStock(updateStock)).ReturnsAsync(-1);

            var result = await _controller.UpdateStock(updateStock);

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("It is not possible order this product, becase is not in warehouse", badRequest.Value);
        }

        [Fact]
        public async Task UpdateStock_ValidUpdate_Ok()
        {
            var updateStock = new UpdateStock { ProductId = 1, StockChange = 1 };
            _serviceMock.Setup(s => s.ProductExistById(1)).ReturnsAsync(true);
            _serviceMock.Setup(s => s.UpdateStock(updateStock)).ReturnsAsync(10);

            var result = await _controller.UpdateStock(updateStock);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Null(okResult.Value);
        }
    }
}
