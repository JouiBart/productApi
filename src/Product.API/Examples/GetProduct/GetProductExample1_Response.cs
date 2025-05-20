using Swashbuckle.AspNetCore.Filters;
using System.Reflection.Metadata.Ecma335;

namespace Product.API.Examples.GetProduct
{
    public class GetProductExample1_Response : IExamplesProvider<Product.Domain.Models.Product>
    {
        public Product.Domain.Models.Product GetExamples()
        {
            return new Product.Domain.Models.Product
            {
                Id = 1,
                ProductName = "Sample Product",
                ImageUrl = "https://example.com/image.jpg",
                Price = 19.99m,
                DescriptionOfProduct = "Description for the sample product.",
                QuatityStock = 100,
                ProductCode = "P001"
            };
        }
    }
}
