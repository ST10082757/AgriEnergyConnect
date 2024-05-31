using System.ComponentModel.DataAnnotations;

namespace agriEnergy.Models
{
    public class Farmers
    {        
        //--------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Gets or sets the ID of the farmer.
        /// </summary>

        public int Id { get; set; }
        //--------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Gets or sets the name of the farmer.
        /// </summary>
        [MaxLength(100)]
        public string name { get; set; } = "";
        /// <summary>
        /// Gets or sets the email of the farmer.
        /// </summary>
        [MaxLength(100)]
        public string email { get; set; } = "";
        //--------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Gets or sets the role of the farmer.
        /// </summary>
        [MaxLength(100)]
        public string role { get; set; } = "";
        //--------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Gets or sets the password of the farmer.
        /// </summary>
        [MaxLength(100)]
        public string password { get; set; } = "";

    }
}
        //---------------------------------------- END OF FILE -------------------------------------------------------//
