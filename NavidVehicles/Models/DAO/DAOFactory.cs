namespace NavidVehicles.Models.DAO
{
    /// <summary>
    /// 
    /// </summary>
    public class DAOFactory : IDAOFactory
    {
        private IVehicleDAO _vehicleDAO;

        /// <summary>
        /// 
        /// </summary>
        public DAOFactory() : this(new VehicleDAO())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleDAO"></param>
        public DAOFactory(IVehicleDAO vehicleDAO)
        {
            _vehicleDAO = vehicleDAO;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IVehicleDAO GetVehicleDAO()
        {
            return _vehicleDAO;
        }
    }
}