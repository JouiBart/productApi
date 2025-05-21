using Microsoft.EntityFrameworkCore;
using Product.Domain.Enums;
using Product.Domain.Models;
using Product.Infrastructure;
using Product.Infrastructure.Models;
using Product.Infrastructure.Repositories.v2;
using Products.Tests.Helpers;
namespace Products.Tests.Repositories
{
    public class ProductRepository_v2Tests
    {
        private ProductContext GetInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<ProductContext>()
                .UseInMemoryDatabase(databaseName: "ProductDb_" + System.Guid.NewGuid())
                .Options;
            return new ProductContext(options);
        }


        [Fact]
        public async Task ProductExistById_ReturnsTrue_IfExists()
        {
            using var ctx = GetInMemoryContext();
            var product = PRO_ProductMockupHelper.GetProducts_50_Products().First();
            ctx.PRO_Products.Add(product);
            ctx.SaveChanges();

            var repo = new ProductRepository_v2(ctx);
            var exists = await repo.ProductExistById(product.Id);

            Assert.True(exists);
        }

        [Fact]
        public async Task ProductExistById_ReturnsFalse_IfNotExists()
        {
            using var ctx = GetInMemoryContext();
            var repo = new ProductRepository_v2(ctx);
            var exists = await repo.ProductExistById(999);
            Assert.False(exists);
        }

        [Fact]
        public async Task GetAllProducts_ReturnsPagedOrderedList()
        {
            using var ctx = GetInMemoryContext();
            ctx.PRO_Products.AddRange(
                PRO_ProductMockupHelper.GetProducts_50_Products().Take(10)
            );
            ctx.SaveChanges();

            var repo = new ProductRepository_v2(ctx);
            var products = await repo.GetAllProducts(1, 2, ProductOrderEnum.ProdAsc);

            Assert.Equal(2, ((List<PRO_Product>)products).Count);
        }

        [Fact]
        public async Task GetProduct_ReturnsProduct_IfExists()
        {
            using var ctx = GetInMemoryContext();
            var product = PRO_ProductMockupHelper.GetProducts_50_Products().First();
            ctx.PRO_Products.Add(product);
            ctx.SaveChanges();

            var repo = new ProductRepository_v2(ctx);
            var result = await repo.GetProduct(product.Id);

            Assert.NotNull(result);
            Assert.Equal(product.Id, result.Id);
        }

        [Fact]
        public async Task GetProduct_ReturnsNull_IfNotExists()
        {
            using var ctx = GetInMemoryContext();
            var repo = new ProductRepository_v2(ctx);
            var result = await repo.GetProduct(999);
            Assert.Null(result);
        }

        [Fact]
        public async Task CreateProduct_AddsProduct()
        {
            using var ctx = GetInMemoryContext();
            var repo = new ProductRepository_v2(ctx);
            var product = PRO_ProductMockupHelper.GetProducts_50_Products().First();

            var result = await repo.CreateProduct(product);

            Assert.True(result);
            Assert.Single(ctx.PRO_Products);
        }

        [Fact]
        public async Task ProductExistByProductCode_ReturnsTrue_IfExists()
        {
            using var ctx = GetInMemoryContext();
            var product = PRO_ProductMockupHelper.GetProducts_50_Products().First();
            ctx.PRO_Products.Add(product);
            ctx.SaveChanges();

            var repo = new ProductRepository_v2(ctx);
            var exists = await repo.ProductExistByProductCode(product.ProductCode);

            Assert.True(exists);
        }

        [Fact]
        public async Task ProductExistByProductCode_ReturnsFalse_IfNotExists()
        {
            using var ctx = GetInMemoryContext();
            var repo = new ProductRepository_v2(ctx);
            var exists = await repo.ProductExistByProductCode("NOT_EXIST");
            Assert.False(exists);
        }

        [Theory]
        [InlineData(2, 2)]
        [InlineData(2, -1)]
        [InlineData(0, 10)]
        [InlineData(10, -10)]
        public async Task UpdateStock_UpdatesStockCorrectly(int @startStock, int @addToStock)
        {
            using var ctx = GetInMemoryContext();
            var product = PRO_ProductMockupHelper.GetProducts_50_Products().First();
            product.QuatityStock = @startStock;
            ctx.PRO_Products.Add(product);
            ctx.SaveChanges();

            var repo = new ProductRepository_v2(ctx);
            var update = new UpdateStock { ProductId = product.Id, StockChange = @addToStock };
            await repo.UpdateStock(update);

            
            Assert.Equal(@startStock + @addToStock, ctx.PRO_Products.First(x => x.Id == product.Id).QuatityStock);
        }

        [Theory]
        [InlineData(0, -1)]
        [InlineData(2, -3)]
        public async Task UpdateStock_ReturnsNegativeStock_IfBelowZero(int @startStock, int @addToStock)
        {
            using var ctx = GetInMemoryContext();
            var product = PRO_ProductMockupHelper.GetProducts_50_Products().First();
            product.QuatityStock = @startStock;
            ctx.PRO_Products.Add(product);
            ctx.SaveChanges();

            var repo = new ProductRepository_v2(ctx);
            var update = new UpdateStock { ProductId = product.Id, StockChange = @addToStock };
            var newStock = await repo.UpdateStock(update);

            Assert.True(newStock < 0);
        }
    }
}
