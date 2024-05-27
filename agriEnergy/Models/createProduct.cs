using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace agriEnergy.Models
{
    public class createProduct
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string productName { get; set; } = "";

        [Required, MaxLength(100)]
        public string category { get; set; } = "";

        [Required]
        [Range(0, double.MaxValue)]
        public decimal price { get; set; }
        public string userID { get; set; } // Add this if not present

    }
}
