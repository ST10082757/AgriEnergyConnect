using System.ComponentModel.DataAnnotations;

namespace agriEnergy.Models
{
    public class Farmers
    {
         public int Id { get; set; }

        [MaxLength(100)]
        public string name { get; set; } = "";

        [MaxLength(100)]
        public string email { get; set; } = "";

        [MaxLength(100)]
        public string role { get; set; } = "";

        [MaxLength(100)]
        public string password { get; set; } = "";

       
    }
}
