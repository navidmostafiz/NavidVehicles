using System.Linq;
using System.Data.Entity;
using NavidVehicles.Models.BO;
using System.Collections.Generic;

namespace NavidVehicles.Models.DAO
{
    /// <summary>
    /// 
    /// </summary>
    public class VehicleDAO : IVehicleDAO
    {
        private VehicleContext _vehicleContext;

        /// <summary>
        /// 
        /// </summary>
        public VehicleDAO() : this(new VehicleContext())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleContext"></param>
        public VehicleDAO(VehicleContext vehicleContext)
        {
            _vehicleContext = vehicleContext;
        }

        private VehicleContext GetContext()
        {
            return _vehicleContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Vehicle> GetAllVehicles()
        {
            return GetContext().Vehicles.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public bool DeleteVehicle(Vehicle vehicle)
        {
            GetContext().Vehicles.Remove(vehicle);
            GetContext().SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public bool UpdateVehicle(Vehicle vehicle)
        {
            if (GetVehicleById(vehicle.Id) != null)
            {
                GetContext().Entry(vehicle).State = EntityState.Modified;
                GetContext().SaveChangesAsync();

                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public Vehicle CreateVehicle(Vehicle vehicle)
        {
            GetContext().Vehicles.Add(vehicle);
            GetContext().SaveChangesAsync();

            return vehicle;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Vehicle GetVehicleById(int id)
        {
            return GetContext().Vehicles.Find(id);
        }
    }
}