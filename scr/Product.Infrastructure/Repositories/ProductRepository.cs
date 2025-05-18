using Microsoft.EntityFrameworkCore;
using Product.Infrastructure.Models;

namespace Product.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _productContext;

        public ProductRepository(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public async Task<bool> ProductExistById(int id)
        {
            return await _productContext.PRO_Products.AnyAsync(x => x.Id == id);
        }


        public async Task<IEnumerable<PRO_Product>> GetAllProducts()
        {
            return await _productContext.PRO_Products.AsNoTracking().ToListAsync();
        }


        public async Task<PRO_Product> GetProduct(int id)
        {
            return await _productContext.PRO_Products.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<bool> CreateProduct(PRO_Product newProduct)
        {
            _productContext.PRO_Products.Add(newProduct);

            await _productContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateStockAsync(int productId, int newStock)
        {
            var product = await _productContext.PRO_Products.FindAsync(productId);
            product.QuatityStock = newStock;

            await _productContext.SaveChangesAsync();

            return true;
        }


        public async Task<bool> ProductExistByProductCode(string productCode)
        {
            return await _productContext.PRO_Products.AnyAsync(x => x.ProductCode == productCode);
        }
    }
}
