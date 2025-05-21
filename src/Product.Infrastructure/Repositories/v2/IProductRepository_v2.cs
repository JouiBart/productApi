using Product.Domain.Enums;
using Product.Domain.Models;
using Product.Infrastructure.Models;

namespace Product.Infrastructure.Repositories.v2
{
    public interface IProductRepository_v2
    {

        Task<bool> ProductExistById(int id);

        Task<bool> CreateProduct(PRO_Product newProduct);

        Task<IEnumerable<PRO_Product>> GetAllProducts(int currentPage, int pageSize, ProductOrderEnum order);

        Task<PRO_Product> GetProduct(int id);

        Task<bool> ProductExistByProductCode(string productCode);

        Task<int> UpdateStock(UpdateStock updateStock);
    }
}