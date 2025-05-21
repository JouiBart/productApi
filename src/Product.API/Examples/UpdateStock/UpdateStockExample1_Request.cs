using Swashbuckle.AspNetCore.Filters;

namespace Product.API.Examples.UpdateStock
{
    public class UpdateStockExample1_Request : IExamplesProvider<Product.Domain.Models.UpdateStock>
    {
        public Product.Domain.Models.UpdateStock GetExamples()
        {
            return new Product.Domain.Models.UpdateStock
            {
                ProductId = 1,
                StockChange = 10
            };
        }

    }
}
