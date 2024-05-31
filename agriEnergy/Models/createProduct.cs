using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace agriEnergy.Models
{
    public class createProduct
    {
        //--------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Gets or sets the ID of the product.
        /// </summary>
        public int Id { get; set; }

        //--------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        [Required, MaxLength(100)]
        public string productName { get; set; } = "";
        //--------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Gets or sets the category of the product.
        /// </summary>
        [Required, MaxLength(100)]
        public string category { get; set; } = "";
        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        [Required]
        [Range(0, double.MaxValue)]
        public decimal price { get; set; }
        /// <summary>
        /// Gets or sets the user ID associated with the product.
        /// </summary>
        public string userID { get; set; } // Add this if not present

    }
}
        //---------------------------------------- END OF FILE -------------------------------------------------------//
