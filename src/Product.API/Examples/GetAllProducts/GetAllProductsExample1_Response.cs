using Swashbuckle.AspNetCore.Filters;

namespace Product.API.Examples.GetAllProducts
{
    public class GetAllProductsExample1_Response : IExamplesProvider<IEnumerable<Product.Domain.Models.Product>>
    {
        public IEnumerable<Product.Domain.Models.Product> GetExamples()
        {
            return new[]
{
    new Product.Domain.Models.Product
    {
        Id = 1,
        ProductName = "Sample Product 1",
        ImageUrl = "https://example.com/image1.jpg",
        Price = 19.99m,
        DescriptionOfProduct = "Description for Product 1",
        QuatityStock = 100,
        ProductCode = "P001"
    },
    new Product.Domain.Models.Product
    {
        Id = 2,
        ProductName = "Sample Product 2",
        ImageUrl = "https://example.com/image2.jpg",
        Price = 29.99m,
        DescriptionOfProduct = "Description for Product 2",
        QuatityStock = 200,
        ProductCode = "P002"
    },
    new Product.Domain.Models.Product
    {
        Id = 3,
        ProductName = "Sample Product 3",
        ImageUrl = "https://example.com/image3.jpg",
        Price = 39.99m,
        DescriptionOfProduct = "Description for Product 3",
        QuatityStock = 300,
        ProductCode = "P003"
    },
    new Product.Domain.Models.Product
    {
        Id = 4,
        ProductName = "Sample Product 4",
        ImageUrl = "https://example.com/image4.jpg",
        Price = 49.99m,
        DescriptionOfProduct = "Description for Product 4",
        QuatityStock = 400,
        ProductCode = "P004"
    },
    new Product.Domain.Models.Product
    {
        Id = 5,
        ProductName = "Sample Product 5",
        ImageUrl = "https://example.com/image5.jpg",
        Price = 59.99m,
        DescriptionOfProduct = "Description for Product 5",
        QuatityStock = 500,
        ProductCode = "P005"
    },
    new Product.Domain.Models.Product
    {
        Id = 6,
        ProductName = "Sample Product 6",
        ImageUrl = "https://example.com/image6.jpg",
        Price = 69.99m,
        DescriptionOfProduct = "Description for Product 6",
        QuatityStock = 600,
        ProductCode = "P006"
    },
    new Product.Domain.Models.Product
    {
        Id = 7,
        ProductName = "Sample Product 7",
        ImageUrl = "https://example.com/image7.jpg",
        Price = 79.99m,
        DescriptionOfProduct = "Description for Product 7",
        QuatityStock = 700,
        ProductCode = "P007"
    },
    new Product.Domain.Models.Product
    {
        Id = 8,
        ProductName = "Sample Product 8",
        ImageUrl = "https://example.com/image8.jpg",
        Price = 89.99m,
        DescriptionOfProduct = "Description for Product 8",
        QuatityStock = 800,
        ProductCode = "P008"
    },
    new Product.Domain.Models.Product
    {
        Id = 9,
        ProductName = "Sample Product 9",
        ImageUrl = "https://example.com/image9.jpg",
        Price = 99.99m,
        DescriptionOfProduct = "Description for Product 9",
        QuatityStock = 900,
        ProductCode = "P009"
    },
    new Product.Domain.Models.Product
    {
        Id = 10,
        ProductName = "Sample Product 10",
        ImageUrl = "https://example.com/image10.jpg",
        Price = 109.99m,
        DescriptionOfProduct = "Description for Product 10",
        QuatityStock = 1000,
        ProductCode = "P010"
    },
    new Product.Domain.Models.Product
    {
        Id = 11,
        ProductName = "Sample Product 11",
        ImageUrl = "https://example.com/image11.jpg",
        Price = 119.99m,
        DescriptionOfProduct = "Description for Product 11",
        QuatityStock = 1100,
        ProductCode = "P011"
    },
    new Product.Domain.Models.Product
    {
        Id = 12,
        ProductName = "Sample Product 12",
        ImageUrl = "https://example.com/image12.jpg",
        Price = 129.99m,
        DescriptionOfProduct = "Description for Product 12",
        QuatityStock = 1200,
        ProductCode = "P012"
    },
    new Product.Domain.Models.Product
    {
        Id = 13,
        ProductName = "Sample Product 13",
        ImageUrl = "https://example.com/image13.jpg",
        Price = 139.99m,
        DescriptionOfProduct = "Description for Product 13",
        QuatityStock = 1300,
        ProductCode = "P013"
    },
    new Product.Domain.Models.Product
    {
        Id = 14,
        ProductName = "Sample Product 14",
        ImageUrl = "https://example.com/image14.jpg",
        Price = 149.99m,
        DescriptionOfProduct = "Description for Product 14",
        QuatityStock = 1400,
        ProductCode = "P014"
    },
    new Product.Domain.Models.Product
    {
        Id = 15,
        ProductName = "Sample Product 15",
        ImageUrl = "https://example.com/image15.jpg",
        Price = 159.99m,
        DescriptionOfProduct = "Description for Product 15",
        QuatityStock = 1500,
        ProductCode = "P015"
    },
    new Product.Domain.Models.Product
    {
        Id = 16,
        ProductName = "Sample Product 16",
        ImageUrl = "https://example.com/image16.jpg",
        Price = 169.99m,
        DescriptionOfProduct = "Description for Product 16",
        QuatityStock = 1600,
        ProductCode = "P016"
    },
    new Product.Domain.Models.Product
    {
        Id = 17,
        ProductName = "Sample Product 17",
        ImageUrl = "https://example.com/image17.jpg",
        Price = 179.99m,
        DescriptionOfProduct = "Description for Product 17",
        QuatityStock = 1700,
        ProductCode = "P017"
    },
    new Product.Domain.Models.Product
    {
        Id = 18,
        ProductName = "Sample Product 18",
        ImageUrl = "https://example.com/image18.jpg",
        Price = 189.99m,
        DescriptionOfProduct = "Description for Product 18",
        QuatityStock = 1800,
        ProductCode = "P018"
    },
    new Product.Domain.Models.Product
    {
        Id = 19,
        ProductName = "Sample Product 19",
        ImageUrl = "https://example.com/image19.jpg",
        Price = 199.99m,
        DescriptionOfProduct = "Description for Product 19",
        QuatityStock = 1900,
        ProductCode = "P019"
    },
    new Product.Domain.Models.Product
    {
        Id = 20,
        ProductName = "Sample Product 20",
        ImageUrl = "https://example.com/image20.jpg",
        Price = 209.99m,
        DescriptionOfProduct = "Description for Product 20",
        QuatityStock = 2000,
        ProductCode = "P020"
    }
};
        }
    }
}
