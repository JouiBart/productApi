﻿using Product.Domain.Interfaces.v1;
using Product.Domain.Models;
using Product.Infrastructure.Repositories;

namespace Product.API.Services.v1
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Domain.Models.Product>> GetAllProducts()
        {   
            var products = await _productRepository.GetAllProducts();

            return products.Select(x => new Domain.Models.Product
            {
                ProductCode = x.ProductCode,
                ImageUrl = x.ImageUrl,
                ProductName = x.ProductName,
                Price = x.Price,
                QuatityStock = x.QuatityStock,
                Id = x.Id
            }).ToList();
        }


        public async Task<Domain.Models.Product?> GetProduct(int id)
        {
            var product = await _productRepository.GetProduct(id);;

            return product == null ? null : new Domain.Models.Product
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

            await _productRepository.CreateProduct(newProduct);

            return true;
        }

        public async Task<int> UpdateStock(UpdateStock updateStock)
        {
            return await _productRepository.UpdateStock(updateStock);
        }

        public async Task<bool> ProductExistById(int id)
        {
            return await _productRepository.ProductExistById(id);
        }

        public Task<bool> ProductExistByProductCode(string productCode)
        {
            return _productRepository.ProductExistByProductCode(productCode);
        }
    }
}
