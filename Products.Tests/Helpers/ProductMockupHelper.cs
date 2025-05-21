namespace Products.Tests.Helpers
{
    public static class ProductMockupHelper
    {

        public static List<Product.Domain.Models.Product> Get_10_Products()
        {
            return new List<Product.Domain.Models.Product>
            {
                new Product.Domain.Models.Product
                {
                    Id = 1,
                    ProductName = "Wireless Mouse",
                    ImageUrl = "https://example.com/images/wireless-mouse.jpg",
                    Price = 499.99m,
                    DescriptionOfProduct = "A comfortable wireless mouse with ergonomic design and long battery life.",
                    QuatityStock = 150,
                    ProductCode = ""
                },
                new Product.Domain.Models.Product
                {
                    Id = 2,
                    ProductName = "Mechanical Keyboard",
                    ImageUrl = "https://example.com/images/mechanical-keyboard.jpg",
                    Price = 1599.00m,
                    DescriptionOfProduct = "RGB backlit mechanical keyboard with blue switches and detachable wrist rest.",
                    QuatityStock = 80,
                    ProductCode = ""
                },
                new Product.Domain.Models.Product
                {
                    Id = 3,
                    ProductName = "27\" 4K Monitor",
                    ImageUrl = "https://example.com/images/4k-monitor.jpg",
                    Price = 7999.00m,
                    DescriptionOfProduct = "Ultra HD 4K monitor with IPS panel and adjustable stand.",
                    QuatityStock = 40,
                    ProductCode = ""
                },
                new Product.Domain.Models.Product
                {
                    Id = 4,
                    ProductName = "USB-C Docking Station",
                    ImageUrl = "https://example.com/images/usb-c-dock.jpg",
                    Price = 2499.50m,
                    DescriptionOfProduct = "Multi-port USB-C docking station with HDMI, Ethernet, and SD card reader.",
                    QuatityStock = 120,
                    ProductCode = ""
                },
                new Product.Domain.Models.Product
                {
                    Id = 5,
                    ProductName = "Noise Cancelling Headphones",
                    ImageUrl = "https://example.com/images/noise-cancelling-headphones.jpg",
                    Price = 3499.00m,
                    DescriptionOfProduct = "Wireless over-ear headphones with active noise cancellation and 30-hour battery life.",
                    QuatityStock = 60,
                    ProductCode = ""
                },
                new Product.Domain.Models.Product
                {
                    Id = 6,
                    ProductName = "Bluetooth Speaker",
                    ImageUrl = "https://example.com/images/bluetooth-speaker.jpg",
                    Price = 899.00m,
                    DescriptionOfProduct = "Portable Bluetooth speaker with deep bass and 12-hour playtime.",
                    QuatityStock = 200,
                    ProductCode = ""
                },
                new Product.Domain.Models.Product
                {
                    Id = 7,
                    ProductName = "Webcam 1080p",
                    ImageUrl = "https://example.com/images/webcam-1080p.jpg",
                    Price = 1299.00m,
                    DescriptionOfProduct = "Full HD webcam with built-in microphone and privacy cover.",
                    QuatityStock = 75,
                    ProductCode = ""
                },
                new Product.Domain.Models.Product
                {
                    Id = 8,
                    ProductName = "Gaming Chair",
                    ImageUrl = "https://example.com/images/gaming-chair.jpg",
                    Price = 4999.00m,
                    DescriptionOfProduct = "Ergonomic gaming chair with adjustable armrests and lumbar support.",
                    QuatityStock = 30,
                    ProductCode = ""
                },
                new Product.Domain.Models.Product
                {
                    Id = 9,
                    ProductName = "External SSD 1TB",
                    ImageUrl = "https://example.com/images/external-ssd.jpg",
                    Price = 2999.00m,
                    DescriptionOfProduct = "High-speed portable SSD with USB-C connectivity.",
                    QuatityStock = 90,
                    ProductCode = ""
                },
                new Product.Domain.Models.Product
                {
                    Id = 10,
                    ProductName = "Smartwatch",
                    ImageUrl = "https://example.com/images/smartwatch.jpg",
                    Price = 3999.00m,
                    DescriptionOfProduct = "Water-resistant smartwatch with heart rate monitor and GPS.",
                    QuatityStock = 110,
                    ProductCode = ""
                }
            };
        }

    }
}
    