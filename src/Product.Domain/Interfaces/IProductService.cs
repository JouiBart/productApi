using Product.Domain.Models;

namespace Product.Domain.Interfaces
{
    public interface IProductService
    {
        Task<bool> CreateProduct(CreateProduct product);
        Task<IEnumerable<Domain.Models.Product>> GetAllProducts();
        Task<Domain.Models.Product?> GetProduct(int id);
        Task<int> UpdateStock(UpdateStock updateStock);

        Task<bool> ProductExistById(int id);

        Task<bool> ProductExistByProductCode(string id);
    }
}