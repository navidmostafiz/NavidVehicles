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
            List<Vehicle> vehicleList;

            try
            {
                vehicleList = GetContext().Vehicles.ToList();
            }
            catch (System.Exception)
            {
                throw;
            }

            return vehicleList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public bool DeleteVehicle(Vehicle vehicle)
        {
            try
            {
                GetContext().Vehicles.Remove(vehicle);
                GetContext().SaveChangesAsync();
            }
            catch (System.Exception)
            {
                throw;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public bool UpdateVehicle(Vehicle vehicle)
        {
            Vehicle vehicleToUpdate = GetVehicleById(vehicle.Id);

            if (vehicleToUpdate != null)
            {
                vehicleToUpdate.Year = vehicle.Year;
                vehicleToUpdate.Make = vehicle.Make;
                vehicleToUpdate.Model = vehicle.Model;

                try
                {
                    GetContext().Entry(vehicleToUpdate).State = EntityState.Modified;
                    GetContext().SaveChangesAsync();
                }
                catch (System.Exception)
                {
                    throw;
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="createVehicle"></param>
        /// <returns></returns>
        public Vehicle CreateVehicle(Vehicle createVehicle)
        {
            try
            {
                GetContext().Vehicles.Add(createVehicle);
                GetContext().SaveChangesAsync();
            }
            catch (System.Exception)
            {
                throw;
            }

            return createVehicle;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Vehicle GetVehicleById(int id)
        {
            try
            {
                return GetContext().Vehicles.Find(id);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}