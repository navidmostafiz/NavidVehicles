using NavidVehicles.Models.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavidVehicles.Models.DAO
{
    public interface IVehicleDAO
    {
        List<Vehicle> GetAllVehicles();
        Vehicle GetVehicleById(int id);
        Vehicle CreateVehicle(Vehicle newVehicle);
        bool UpdateVehicle(Vehicle newVehicle);
        bool DeleteVehicle(Vehicle vehicle);
    }
}
