using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Models
{
    public class UpdateStock
    {
        /// <summary>
        /// ProductId of the product to update stock.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// StockChange is the amount to add or remove from the current stock.
        /// </summary>
        public int StockChange { get; set; }
    }
}
