using agriEnergy.Models;
using Microsoft.EntityFrameworkCore;

namespace agriEnergy.Areas.Identity.Data
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {

        }
        public DbSet<Product> ProductsDetails { get; set; }
    public DbSet<agriEnergyUser> AspNetUsers { get; set; } // Ensure it uses the correct table name

    }
}
