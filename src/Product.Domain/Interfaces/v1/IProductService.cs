using Product.Domain.Models;

namespace Product.Domain.Interfaces.v1
{
    public interface IProductService
    {
        Task<bool> CreateProduct(CreateProduct product);
        Task<IEnumerable<Models.Product>> GetAllProducts();
        Task<Models.Product?> GetProduct(int id);
        Task<int> UpdateStock(UpdateStock updateStock);

        Task<bool> ProductExistById(int id);

        Task<bool> ProductExistByProductCode(string id);
    }
}