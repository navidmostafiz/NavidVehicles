using System.ComponentModel.DataAnnotations;

namespace NavidVehicles.Models.BO
{
    public class Vehicle
    {
        /// <summary>
        /// Vehicle Id.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Vehicle year of manufacture.
        /// </summary>
        [Range(1950, 2050)]
        public int Year { get; set; }

        /// <summary>
        /// Vehicle manufacturer.
        /// </summary>
        [StringLength(100, MinimumLength = 0)]
        public string Make { get; set; }

        /// <summary>
        /// Vehicle model.
        /// </summary>
        [StringLength(100, MinimumLength = 0)]
        public string Model { get; set; }
    }
}