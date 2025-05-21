using Microsoft.EntityFrameworkCore;
using Product.Domain.Enums;
using Product.Domain.Models;
using Product.Infrastructure.Models;

namespace Product.Infrastructure.Repositories.v2
{
    public class ProductRepository_v2 : IProductRepository_v2
    {
        private readonly ProductContext _productContext;

        public ProductRepository_v2(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public async Task<bool> ProductExistById(int id)
        {
            return await _productContext.PRO_Products.AnyAsync(x => x.Id == id);
        }


        public async Task<IEnumerable<PRO_Product>> GetAllProducts(int currentPage, int pageSize, ProductOrderEnum order)
        {
            IQueryable<PRO_Product> query = _productContext.PRO_Products.AsNoTracking();

            switch (order)
            {
                case ProductOrderEnum.ProdAsc:
                    query = query.OrderBy(p => p.ProductName);
                    break;
                case ProductOrderEnum.ProdDesc:
                    query = query.OrderByDescending(p => p.ProductName);
                    break;
                case ProductOrderEnum.PriceAsc:
                    query = query.OrderBy(p => p.Price);
                    break;
                case ProductOrderEnum.PriceDesc:
                    query = query.OrderByDescending(p => p.Price);
                    break;
                default:
                    query = query.OrderBy(p => p.Id);
                    break;
            }

            return await query
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
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

        public async Task<int> UpdateStock(UpdateStock updateStock)
        {
            var product = await _productContext.PRO_Products.FindAsync(updateStock.ProductId);
            product.QuatityStock += updateStock.StockChange;

            await _productContext.SaveChangesAsync();

            return product.QuatityStock;
        }


        public async Task<bool> ProductExistByProductCode(string productCode)
        {
            return await _productContext.PRO_Products.AnyAsync(x => x.ProductCode == productCode);
        }
    }
}
