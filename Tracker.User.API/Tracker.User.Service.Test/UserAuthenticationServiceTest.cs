using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;
using System.Linq;
using MockQueryable.Moq;
using Tracker.User.API.Middlewares;
using Tracker.User.Data.Repository;
using Tracker.User.DTO;
using Tracker.User.Service;

namespace Tracker.User.Service.Test
{
    [TestClass]
    public class UserAuthenticationServiceTest
    {
        private readonly IMapper mapperMock;
        private readonly IUserAuthenticationService userAuthenticationService;

        /// <summary>
        /// Construtor, configuring the mock objects and automapper
        /// </summary>
        public UserAuthenticationServiceTest()
        {
            // Mapper configuration
            var myProfile = new MapperProfile();
            var _config = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            mapperMock = new Mapper(_config);

            var configuration = new ConfigurationBuilder()
              .AddJsonFile("appSettings.Test.json")
              .Build();

            // Repository mock object and method setup.
            var userRepoMock = new Mock<IUserRepository>();
            var mockData = UserMockdata.AsQueryable().BuildMock();
            userRepoMock.Setup(x => x.FindByCondition(It.IsAny<Expression<Func<Tracker.User.Data.Models.User, bool>>>())).Returns(mockData.Object);

            //The service instance
            userAuthenticationService = new Tracker.User.Service.UserAuthenticationService(configuration, userRepoMock.Object, mapperMock);
        }

        [TestMethod]
        public async Task Call_Method_Authenticate_Returns_Token()
        {
            UserDTO user = new UserDTO()
            {
                UserName = "test_user",
                Password = "test_password"
            };

            var userWithToken = await userAuthenticationService.Authenticate(user);

            Assert.IsNotNull(userWithToken);
            Assert.IsNotNull(userWithToken.Token);
            Assert.IsNull(userWithToken.Password);
        }

        /// <summary>
        /// The test user data.
        /// </summary>
        private List<Tracker.User.Data.Models.User> UserMockdata
        {
            get
            {
                return new List<Tracker.User.Data.Models.User>()
                {
                  new Tracker.User.Data.Models.User() 
                  {
                        UserId = Guid.NewGuid(),
                        UserName = "test_user",
                        Password = "test_password",
                        Role = "Admin"
                  }
                };
            }
        }
    }
}
