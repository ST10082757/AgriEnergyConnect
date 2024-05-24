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
        public decimal price { get; set; }
    }
}
