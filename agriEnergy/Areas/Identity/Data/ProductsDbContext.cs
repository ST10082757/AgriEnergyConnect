using agriEnergy.Models;
using Microsoft.EntityFrameworkCore;

namespace agriEnergy.Areas.Identity.Data
{//--------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// DbContext class for the Products table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {

        }
        public DbSet<Product> ProductsDetails { get; set; }
    public DbSet<agriEnergyUser> AspNetUsers { get; set; } // Ensure it uses the correct table name

    }
}
//---------------------------------------- END OF FILE -------------------------------------------------------//
