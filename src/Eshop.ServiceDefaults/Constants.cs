using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.ServiceDefaults
{
    public static class Constants
    {
        public const string MSSQL_PRODUCTS = "ProductApi";

        public const string REDIS_SERVER = "cache";
        public const string REDIS_PRODUCTS = "products";



        /// <summary>
        /// Represents the prefix used for caching product-related data.
        /// </summary>
        /// 
        /// <remarks>This constant can be used as a key prefix when storing or retrieving product data in
        /// a cache. For example, appending a product ID to this prefix can create a unique cache key for each
        /// product.</remarks>
        public const string CACHE_PRODUCTS = "Product_";
    }
}
