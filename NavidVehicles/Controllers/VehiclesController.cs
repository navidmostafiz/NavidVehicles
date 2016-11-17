using System.Web.Http;
using NavidVehicles.Models.BO;
using NavidVehicles.Models.DAO;
using System.Collections.Generic;
using System.Web.Http.Description;
using System.Web.Http.Cors;

namespace NavidVehicles.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/vehicles")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VehiclesController : ApiController
    {

        IDAOFactory _DAOFactory;

        /// <summary>
        /// 
        /// </summary>
        public VehiclesController() : this(new DAOFactory())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DAOFactory"></param>
        public VehiclesController(IDAOFactory DAOFactory)
        {
            _DAOFactory = DAOFactory;
        }

        /// <summary>
        /// GET all vehicles.
        /// </summary>
        // GET: api/vehicles/vehicles
        [Route("vehicles")]
        [ResponseType(typeof(List<Vehicle>))]
        [HttpGet]
        public IHttpActionResult GetAllVehicles()
        {
            List<Vehicle> vehicle = _DAOFactory.GetVehicleDAO().GetAllVehicles();

            if (vehicle.Count == 0)
            {
                return NotFound();
            }

            return Ok(vehicle);
        }

        /// <summary>
        /// Get vehicle by ID.
        /// </summary>
        /// <param name="id">The ID of the data.</param>
        // GET: api/vehicles/vehicles/id
        [Route("vehicles/{id:int}")]
        [ResponseType(typeof(Vehicle))]
        [HttpGet]
        public IHttpActionResult GetVehicleById([FromUri]int id)
        {
            Vehicle vehicle = _DAOFactory.GetVehicleDAO().GetVehicleById(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return Ok(vehicle);
        }

        /// <summary>
        /// Looks up some vehicles by ID.
        /// </summary>
        /// <param name="vehicle">The vehicle.</param>
        // POST: api/vehicles/vehicles
        [Route("vehicles")]
        [ResponseType(typeof(Vehicle))]
        [HttpPost]
        public IHttpActionResult CreateVehicle([FromBody]Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Vehicle createdVehicle = _DAOFactory.GetVehicleDAO().CreateVehicle(vehicle);

            return Ok(createdVehicle);
        }

        /// <summary>
        /// Update vehicles
        /// </summary>
        /// <param name="vehicle">The vehicle.</param>
        // PUT: api/vehicles/vehicles
        [Route("vehicles")]
        [ResponseType(typeof(bool))]
        [HttpPut]
        public IHttpActionResult UpdateVehicle([FromBody]Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Vehicle theVehicle = _DAOFactory.GetVehicleDAO().GetVehicleById(vehicle.Id);

            if (theVehicle == null)
            {
                return NotFound();
            }

            bool result = _DAOFactory.GetVehicleDAO().UpdateVehicle(vehicle);

            if (!result)
            {
                return NotFound();
            }

            return Ok(true);
        }

        /// <summary>
        /// Delete vehicles
        /// </summary>
        /// <param name="id">The ID of the data.</param>
        // Delete: api/vehicles/vehicles
        [Route("vehicles/{id:int}")]
        [ResponseType(typeof(Vehicle))]
        [HttpDelete]
        public IHttpActionResult DeleteVehicle(int id)
        {

            Vehicle vehicle = _DAOFactory.GetVehicleDAO().GetVehicleById(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            bool result = _DAOFactory.GetVehicleDAO().DeleteVehicle(vehicle);

            return Ok(result);
        }
    }
}
