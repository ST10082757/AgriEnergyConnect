using System.ComponentModel.DataAnnotations;

namespace agriEnergy.Models
{
    public class addFarmers
    {
        //--------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Gets or sets the name of the farmer.
        /// </summary>
        [Required, MaxLength(100)]
        public string name { get; set; } = "";
        /// <summary>
        /// Gets or sets the email address of the farmer.
        /// Must be a valid email format.
        /// </summary>
        [Required,MaxLength(100)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please enter a valid email address.")]
        public string email { get; set; } = "";
        //--------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Gets or sets the role of the farmer.
        /// </summary>
        [Required, MaxLength(100)]
        public string role { get; set; } = "";
        //--------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Gets or sets the password for the farmer's account.
        /// </summary>
        [Required, MaxLength(100)]
        public string password { get; set; } = "";

    }
}
