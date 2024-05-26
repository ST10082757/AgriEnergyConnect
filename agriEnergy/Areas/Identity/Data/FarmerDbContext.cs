using agriEnergy.Models;
using Microsoft.EntityFrameworkCore;

namespace agriEnergy.Areas.Identity.Data
{
    public class FarmerDbContext : DbContext
    {

        public FarmerDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Farmers> Farmers { get; set; }


    }

}
