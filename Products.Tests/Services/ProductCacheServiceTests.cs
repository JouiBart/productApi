using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Moq;
using Product.API.Services.v1;
using Product.Domain.Interfaces.v1;
using Products.Tests.Helpers;

namespace Products.Tests.Services
{
    public class ProductCacheServiceTests
    {
        private readonly Mock<IProductService> _productServiceMock;
        private readonly Mock<IDistributedCache> _cacheMock;
        private readonly Mock<IConfiguration> _configurationMock;
        private readonly ProductCacheService _service;

        public ProductCacheServiceTests()
        {
            _productServiceMock = new Mock<IProductService>();
            _cacheMock = new Mock<IDistributedCache>();
            _configurationMock = new Mock<IConfiguration>();
            _configurationMock.Setup(c => c["CacheExpireInMinutes"]).Returns("10");
            _service = new ProductCacheService(_productServiceMock.Object, _cacheMock.Object, _configurationMock.Object);
        }

        [Fact]
        public async Task GetAllProducts_ReturnsProducts()
        {
            var products = ProductMockupHelper.Get_10_Products();
            _productServiceMock.Setup(s => s.GetAllProducts()).ReturnsAsync(products);

            var result = await _service.GetAllProducts();

            Assert.Equal(products, result);
        }


        [Fact]
        public async Task CreateProduct_CallsService()
        {
            var createProduct = CreateProductMock.GetCreateProductMock();

            _productServiceMock.Setup(s => s.CreateProduct(createProduct)).ReturnsAsync(true);

            var result = await _service.CreateProduct(createProduct);

            Assert.True(result);
            _productServiceMock.Verify(s => s.CreateProduct(createProduct), Times.Once);
        }

        [Fact]
        public async Task CreateProduct_Empty_CallsService()
        {
            var createProduct = CreateProductMock.GetCreateProductMock_Base();

            _productServiceMock.Setup(s => s.CreateProduct(createProduct)).ReturnsAsync(true);

            var result = await _service.CreateProduct(createProduct);

            Assert.True(result);
            _productServiceMock.Verify(s => s.CreateProduct(createProduct), Times.Once);
        }


        [Fact]
        public async Task ProductExistByProductCode_CallsService()
        {
            _productServiceMock.Setup(s => s.ProductExistByProductCode("X")).ReturnsAsync(true);

            var result = await _service.ProductExistByProductCode("X");

            Assert.True(result);
            _productServiceMock.Verify(s => s.ProductExistByProductCode("X"), Times.Once);
        }
    }
}
