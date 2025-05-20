using Microsoft.EntityFrameworkCore;
using Product.Infrastructure.Models;

namespace Product.Infrastructure;

public class ProductContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<PRO_Product> PRO_Products { get; set; }
}
