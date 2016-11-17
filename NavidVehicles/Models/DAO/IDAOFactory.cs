using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavidVehicles.Models.DAO
{
    public interface IDAOFactory
    {
        IVehicleDAO GetVehicleDAO();
    }
}
