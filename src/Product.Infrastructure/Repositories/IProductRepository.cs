using Product.Domain.Models;
using Product.Infrastructure.Models;

namespace Product.Infrastructure.Repositories
{
    public interface IProductRepository
    {

        Task<bool> ProductExistById(int id);

        Task<bool> CreateProduct(PRO_Product newProduct);

        Task<IEnumerable<PRO_Product>> GetAllProducts();

        Task<PRO_Product> GetProduct(int id);

        Task<int> UpdateStock(UpdateStock updateStock);

        Task<bool> ProductExistByProductCode(string productCode);
    }
}