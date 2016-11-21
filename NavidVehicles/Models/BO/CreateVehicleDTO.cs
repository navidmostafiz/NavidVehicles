using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NavidVehicles.Models.BO
{
    public class CreateVehicleDTO
    {
        [Range(1950, 2050)]
        public int Year { get; set; }

        [StringLength(100, MinimumLength = 0)]
        public string Make { get; set; }

        [StringLength(100, MinimumLength = 0)]
        public string Model { get; set; }
    }
}