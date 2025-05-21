using Product.Domain.Models;

namespace Products.Tests.Helpers
{
    public static class CreateProductMock
    {
        public static CreateProduct GetCreateProductMock()
        {
            return new CreateProduct
            {
                ProductName = "Test Product",
                ImageUrl = "https://example.com/image.jpg",
                Price = 199.99m,
                DescriptionOfProduct = "A sample product for testing purposes.",
                QuatityStock = 50,
                ProductCode = "TEST-001"
            };
        }

        public static CreateProduct GetCreateProductMock_Base()
        {
            return new CreateProduct
            {
                ProductName = "Test Product",
                ImageUrl = "https://example.com/image.jpg"
            };
        }
    }
}
