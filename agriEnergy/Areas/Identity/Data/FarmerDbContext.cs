using agriEnergy.Models;
using Microsoft.EntityFrameworkCore;

namespace agriEnergy.Areas.Identity.Data
{//--------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// DbContext class for the Farmer model
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
    public class FarmerDbContext : DbContext
    {

        public FarmerDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Farmers> Farmers { get; set; }


    }

}
//---------------------------------------- END OF FILE -------------------------------------------------------//
