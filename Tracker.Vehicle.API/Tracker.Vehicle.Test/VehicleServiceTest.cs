using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MockQueryable.Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tracker.Vehicle.API.Middlewares;
using Tracker.Vehicle.Data.Repository;
using Tracker.Vehicle.DTO;
using Tracker.Vehicle.Service;

namespace Tracker.Vehicle.Test
{
    [TestClass]
    public class VehicleServiceTest
    {
        private readonly IMapper mapperMock;
        private readonly IVehicleService vehicleService;

        private IVehicleRepository VehicleRepoMock
        {
            get
            {
                // Repository mock object and method setup.
                var vehicleRepo = new Mock<IVehicleRepository>();
                vehicleRepo.Setup(x => x.Create(It.IsAny<Data.Models.Vehicle>())).Returns(Task.FromResult(this.VehicleMockdata.First()));
                vehicleRepo.Setup(x => x.CreateUserForVehicle(It.IsAny<Data.Models.Vehicle>(), "token"));

                return vehicleRepo.Object;
            }
        }

        private ILocationRepository LocationRepoMock
        {
            get
            {
                var locationRepo = new Mock<ILocationRepository>();
                return locationRepo.Object;
            }
        }

        /// <summary>
        /// Construtor, configuring the mock objects and automapper
        /// </summary>
        public VehicleServiceTest()
        {
            // Mapper configuration
            var myProfile = new MapperProfile();
            var _config = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            mapperMock = new Mapper(_config);

            var configuration = new ConfigurationBuilder().AddJsonFile("appSettings.Test.json").Build();

            //The service instance.
            vehicleService = new VehicleService(VehicleRepoMock, LocationRepoMock, mapperMock, configuration);
        }

        [TestMethod]
        public async Task Call_Method_Createvehicle_Returns_Object()
        {
            try
            {
                var createdVehicle = await vehicleService.Createvehicle(VehicleDTOMockdata.First(), "token");

                Assert.IsNotNull(createdVehicle);
            } 
            catch (Exception ex)
            {
                Assert.Fail();
            }
            
        }

        /// <summary>
        /// The test User data.
        /// </summary>
        private IList<Data.Models.Vehicle> VehicleMockdata
        {
            get
            {
                return new List<Data.Models.Vehicle>()
                {
                  new Data.Models.Vehicle()
                  {
                        VehicleId = new Guid(),
                        VehicleNo = "AXC340",
                        RegistrationNo = "AXC340KL001",
                        RegistrationDate = DateTime.UtcNow.AddYears(-2),
                        CreatedBy = "System",
                        CreatedDate = DateTime.UtcNow,
                        UpdatedBy = "System",
                        UpdatedDate = DateTime.UtcNow
                  }
                };
            }
        }

        /// <summary>
        /// The test User DTO data.
        /// </summary>
        private IList<VehicleDTO> VehicleDTOMockdata
        {
            get
            {
                return new List<VehicleDTO>()
                {
                  new VehicleDTO()
                  {
                    VehicleId = new Guid(),
                    VehicleNo = "AXC340",
                    RegistrationNo = "AXC340KL001",
                    RegistrationDate = DateTime.UtcNow.AddYears(-2),
                    CreatedBy = "System",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "System",
                    UpdatedDate = DateTime.UtcNow
                  }
                };
            }
        }
    }
}
