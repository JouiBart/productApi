using System.ComponentModel.DataAnnotations;

namespace Product.Domain.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }


        /// <summary>
        /// Product name.
        /// </summary>
        [MaxLength(300)]
        [Required]
        public required string ProductName { get; set; }

        /// <summary>
        /// URL to the image of the product.
        /// </summary>
        [MaxLength(500)]
        [Required]
        public required string ImageUrl { get; set; }

        /// <summary>
        /// Price of the product in CZK
        /// 
        /// Price is from 0 to 1 000 000
        /// </summary>
        [Range(0, 1000000)]
        public decimal Price { get; set; } = 0;

        /// <summary>
        /// Description of the product.
        /// </summary>
        [MaxLength(2000)]
        public string DescriptionOfProduct { get; set; } = string.Empty;

        /// <summary>
        /// How many items are in stock.
        /// 
        /// Maximum 100 000
        /// </summary>
        [Range(0, 100000)]
        public int QuatityStock { get; set; } = 0;

        /// <summary>
        /// Unique code from the creator of the product.
        /// </summary>
        public string ProductCode { get; set; } = string.Empty;
    }
}
