using Product.Domain.Enums;
using Product.Domain.Models;

namespace Product.Domain.Interfaces.v2
{
    public interface IProductService_v2
    {
        Task<bool> CreateProduct(CreateProduct product);

        Task<IEnumerable<Models.Product>> GetAllProducts(int currentPage, int pageSize, ProductOrderEnum order);

        Task<Models.Product?> GetProduct(int id);
        Task<int> UpdateStock(UpdateStock updateStock);

        Task<bool> ProductExistById(int id);

        Task<bool> ProductExistByProductCode(string id);
    }
}