using Swashbuckle.AspNetCore.Filters;

namespace Product.API.Examples.CreateProduct
{
    public class CreateProductExample1_Request : IExamplesProvider<Product.Domain.Models.CreateProduct>
    {
        public Product.Domain.Models.CreateProduct GetExamples()
        {
            return new Product.Domain.Models.CreateProduct
            {
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
