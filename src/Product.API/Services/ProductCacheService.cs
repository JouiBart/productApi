using Microsoft.Extensions.Caching.Distributed;
using Product.Domain.Interfaces;
using Product.Domain.Models;
using System.Text.Json;

namespace Product.API.Services
{
    public class ProductCacheService : IProductCacheService
    {
        private readonly IProductService _productService;
        private readonly IDistributedCache _cache;
        private readonly IConfiguration _configuration;
        private readonly JsonSerializerOptions options;

        public ProductCacheService(IProductService productService, IDistributedCache cache, IConfiguration configuration)
        {
            _productService = productService;
            _cache = cache;
            _configuration = configuration;
        }

        public async Task<IEnumerable<Product.Domain.Models.Product>> GetAllProducts()
        {
            return await _productService.GetAllProducts();
        }


        public async Task<Product.Domain.Models.Product?> GetProduct(int id)
        {
            string cacheKey = $"{Eshop.ServiceDefaults.Constants.CACHE_PRODUCTS}{id}";

            var cachedItem = await _cache.GetStringAsync(cacheKey);

            if (cachedItem != null)
                return JsonSerializer.Deserialize<Product.Domain.Models.Product>(cachedItem);

            var product = await _productService.GetProduct(id);

            await SetCache(cacheKey, JsonSerializer.Serialize(product));

            return product == null ? null : new Product.Domain.Models.Product
            {
                ImageUrl = product.ImageUrl,
                ProductName = product.ProductName,
                Price = product.Price,
                QuatityStock = product.QuatityStock,
                Id = product.Id
            };
        }

        public async Task<bool> CreateProduct(CreateProduct product)
        {

            await _productService.CreateProduct(product);

            return true;
        }

        public async Task<int> UpdateStock(UpdateStock updateStock)
        {
            int stock = await _productService.UpdateStock(updateStock);

            /// if was changed in database, then update cache
            if (stock >=0 )
            {
                string cacheKey = $"{Eshop.ServiceDefaults.Constants.CACHE_PRODUCTS}{updateStock.ProductId}";
                var cachedItem = await _cache.GetStringAsync(cacheKey);
                if (cachedItem != null)
                {
                    var product = JsonSerializer.Deserialize<Product.Domain.Models.Product>(cachedItem);
                    product.QuatityStock = stock;
                    await SetCache(cacheKey, JsonSerializer.Serialize(product));
                }
            }

            return stock;
        }

        public async Task<bool> ProductExistById(int id)
        {
            string cacheKey = $"{Eshop.ServiceDefaults.Constants.CACHE_PRODUCTS}{id}";

            var cachedItem = await _cache.GetStringAsync(cacheKey);

            if (cachedItem != null)
                return true;

            return await _productService.ProductExistById(id);
        }

        public Task<bool> ProductExistByProductCode(string productCode)
        {
            return _productService.ProductExistByProductCode(productCode);
        }

        private async Task<bool> SetCache(string cacheKey, string value)
        {
            await _cache.SetStringAsync(
            cacheKey,
            value,
            new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(int.Parse(_configuration["CacheExpireInMinutes"])) }
            );

            return true;
        }
    }
}
