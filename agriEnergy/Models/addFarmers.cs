using System.ComponentModel.DataAnnotations;

namespace agriEnergy.Models
{
    public class addFarmers
    {

        [Required, MaxLength(100)]
        public string name { get; set; } = "";

        [Required,MaxLength(100)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please enter a valid email address.")]

        public string email { get; set; } = "";

        [Required, MaxLength(100)]
        public string role { get; set; } = "";

        [Required, MaxLength(100)]
        public string password { get; set; } = "";

    }
}
