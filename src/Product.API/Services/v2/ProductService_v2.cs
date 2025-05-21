using Product.Domain.Enums;
using Product.Domain.Interfaces.v1;
using Product.Domain.Interfaces.v2;
using Product.Domain.Models;
using Product.Infrastructure.Repositories;
using Product.Infrastructure.Repositories.v2;

namespace Product.API.Services
{
    public class ProductService_v2 : IProductService_v2
    {
        private readonly IProductRepository_v2 _productRepository_v2;

        public ProductService_v2(IProductRepository_v2 productRepository_v2)
        {
            _productRepository_v2 = productRepository_v2;
        }

        public async Task<IEnumerable<Product.Domain.Models.Product>> GetAllProducts(int currentPage, int pageSize, ProductOrderEnum order)
        {   
            var products = await _productRepository_v2.GetAllProducts(currentPage, pageSize, order);

            return products.Select(x => new Product.Domain.Models.Product
            {
                ProductCode = x.ProductCode,
                ImageUrl = x.ImageUrl,
                ProductName = x.ProductName,
                Price = x.Price,
                QuatityStock = x.QuatityStock,
                Id = x.Id
            }).ToList();
        }


        public async Task<Product.Domain.Models.Product?> GetProduct(int id)
        {
            var product = await _productRepository_v2.GetProduct(id);;

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
            var newProduct = new Infrastructure.Models.PRO_Product
            {
                ImageUrl = product.ImageUrl,
                ProductName = product.ProductName,
                Price = product.Price,
                QuatityStock = product.QuatityStock,
                ProductCode = product.ProductCode
            };

            await _productRepository_v2.CreateProduct(newProduct);

            return true;
        }

        public async Task<int> UpdateStock(UpdateStock updateStock)
        {
            return await _productRepository_v2.UpdateStock(updateStock);
        }

        public async Task<bool> ProductExistById(int id)
        {
            return await _productRepository_v2.ProductExistById(id);
        }

        public Task<bool> ProductExistByProductCode(string productCode)
        {
            return _productRepository_v2.ProductExistByProductCode(productCode);
        }
    }
}
