using Moq;
using System.Web.Http;
using System.Web.Http.Results;
using NavidVehicles.Models.BO;
using NavidVehicles.Models.DAO;
using NavidVehicles.Controllers;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Net;

namespace NavidVehicles.Tests.Controllers
{
    [TestClass]
    public class VehicleControllerTests
    {
        VehiclesController _vehicleController;
        Mock<IVehicleDAO> mockVehicleDAO;
        Mock<IDAOFactory> mockDAOFactory;

        [TestInitialize]
        public void Initialize()
        {
            //mock IVehicleDAO
            mockVehicleDAO = new Mock<IVehicleDAO>();
            mockVehicleDAO.CallBase = true;

            //mock DAOFactory
            mockDAOFactory = new Mock<IDAOFactory>();
            mockDAOFactory.Setup(x => x.GetVehicleDAO()).Returns(mockVehicleDAO.Object);

            //mock controller
            _vehicleController = new VehiclesController(mockDAOFactory.Object);
            _vehicleController.Request = new HttpRequestMessage();
            _vehicleController.Configuration = new HttpConfiguration();
        }

        [TestMethod]
        public void TestGetAllVehicles_OK()
        {
            //mock VehicleList
            List<Vehicle> mockVehicleList = new List<Vehicle>();
            mockVehicleList.Add(new Vehicle()
            {
                Id = 1,
                Year = 2040,
                Make = "Lamborghini",
                Model = "Aventado"
            });

            mockVehicleList.Add(new Vehicle()
            {
                Id = 2,
                Year = 2030,
                Make = "Dodge",
                Model = "Challanger"
            });

            //setting mockVehicleDAO
            mockVehicleDAO.Setup(x => x.GetAllVehicles()).Returns(mockVehicleList);

            //call controller method
            IHttpActionResult result = _vehicleController.GetAllVehicles();
            OkNegotiatedContentResult<List<Vehicle>> contentResult = result as OkNegotiatedContentResult<List<Vehicle>>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.IsTrue(contentResult.Content.Count == 2);
            Assert.AreEqual(mockVehicleList[0], contentResult.Content[0]);
            Assert.AreEqual(mockVehicleList[1], contentResult.Content[1]);
        }

        [TestMethod]
        public void TestGetVehicleById_OK()
        {
            //mock Vehicle
            Vehicle mockVehicle = new Vehicle()
            {
                Id = 1,
                Year = 2040,
                Make = "Lamborghini",
                Model = "Aventado"
            };

            //mock ID
            int mockId = 1;

            //setting mockVehicleDAO
            mockVehicleDAO.Setup(x => x.GetVehicleById(mockId)).Returns(mockVehicle);

            //call controller method
            IHttpActionResult result = _vehicleController.GetVehicleById(mockId);
            OkNegotiatedContentResult<Vehicle> contentResult = result as OkNegotiatedContentResult<Vehicle>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(mockVehicle, contentResult.Content);
        }

        [TestMethod]
        public void TestCreateVehicle_OK()
        {
            //mock Vehicle
            Mock<Vehicle> mockVehicle = new Mock<Vehicle>();

            //mock CreateVehicleDTO
            Mock<CreateVehicleDTO> mockCreateVehicleDTO = new Mock<CreateVehicleDTO>();

            //setting mockVehicleDAO
            mockVehicleDAO.Setup(x => x.CreateVehicle(It.IsAny<Vehicle>())).Returns(mockVehicle.Object);

            //call controller method
            IHttpActionResult actionResult = _vehicleController.CreateVehicle(mockCreateVehicleDTO.Object);
            OkNegotiatedContentResult<Vehicle> contentResult = actionResult as OkNegotiatedContentResult<Vehicle>;
            Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<Vehicle>));
            Assert.AreEqual(contentResult.Content, mockVehicle.Object);
        }

        [TestMethod]
        public void TestUpdateVehicle_OK()
        {
            //mock Vehicle
            Vehicle mockVehicle = new Vehicle()
            {
                Id = 1,
                Year = 2040,
                Make = "Lamborghini",
                Model = "Aventado"
            };

            //setting mockVehicleDAO
            mockVehicleDAO.Setup(x => x.UpdateVehicle(It.IsAny<Vehicle>())).Returns(true);
            mockVehicleDAO.Setup(x => x.GetVehicleById(It.IsAny<int>())).Returns(mockVehicle);

            //call controller method
            IHttpActionResult actionResult = _vehicleController.UpdateVehicle(mockVehicle);
            OkNegotiatedContentResult<bool> contentResult = actionResult as OkNegotiatedContentResult<bool>;
            Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<bool>));
            Assert.IsTrue(contentResult.Content);
        }

        [TestMethod]
        public void TestDeleteVehicle_OK()
        {
            //mock Vehicle
            Vehicle mockVehicle = new Vehicle()
            {
                Id = 1,
                Year = 2040,
                Make = "Lamborghini",
                Model = "Aventado"
            };

            //mock ID
            int mockId = 1;

            //setting mockVehicleDAO
            mockVehicleDAO.Setup(x => x.DeleteVehicle(It.IsAny<Vehicle>())).Returns(true);
            mockVehicleDAO.Setup(x => x.GetVehicleById(It.IsAny<int>())).Returns(mockVehicle);

            //call controller method
            IHttpActionResult actionResult = _vehicleController.DeleteVehicle(mockId);
            OkNegotiatedContentResult<bool> contentResult = actionResult as OkNegotiatedContentResult<bool>;
            Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<bool>));
            Assert.IsTrue(contentResult.Content);

        }
    }
}
