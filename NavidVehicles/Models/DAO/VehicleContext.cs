using System.Data.Entity;
using NavidVehicles.Models.BO;

namespace NavidVehicles.Models.DAO
{
    public class VehicleContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}