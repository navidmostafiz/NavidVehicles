using System.ComponentModel.DataAnnotations;

namespace NavidVehicles.Models.BO
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Range(1950, 2050)]
        public int Year { get; set; }

        [StringLength(100, MinimumLength = 0)]
        public string Make { get; set; }

        [StringLength(100, MinimumLength = 0)]
        public string Model { get; set; }
    }
}