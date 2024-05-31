using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace agriEnergy.Models
{
    public class Product
    {
        //--------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Gets or sets the ID of the product.
        /// </summary>
        [Required]

        public int Id { get; set; }
        //--------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        [MaxLength(100)]
        public string productName { get; set; } = "";
        //--------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Gets or sets the category of the product.
        /// </summary>
        [MaxLength(100)]
        public string category { get; set; } = "";
        //--------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Gets or sets the date the product was added.
        /// </summary>
        public DateTime date { get; set; }
        //--------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        [Precision(16, 2)]
        public decimal price { get; set; }
        //--------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Gets or sets the user ID associated with the product.
        /// </summary>
        [Required]
        public string userID { get; set; } = "";

        /// <summary>
        /// Navigation property to the user who added the product.
        /// </summary>
        public virtual agriEnergyUser User { get; set; }
    }
}
        //---------------------------------------- END OF FILE -------------------------------------------------------//
