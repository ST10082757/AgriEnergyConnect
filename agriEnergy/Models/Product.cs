using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace agriEnergy.Models
{
    public class Product
    {
        [Required]

        public int Id { get; set; }

        [MaxLength(100)]
        public string productName { get; set; } = "";

        [MaxLength(100)]
        public string category { get; set; } = "";

        public DateTime date { get; set; }

        [Precision(16, 2)]
        public decimal price { get; set; }

        [Required]
        public string userID { get; set; } = "";
    }
}
