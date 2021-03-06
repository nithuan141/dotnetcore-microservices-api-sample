using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;
using System.Linq;
using MockQueryable.Moq;
using AutoMapper;
using Tracker.User.API.Middlewares;
using Tracker.User.Data.Repository;
using Tracker.User.DTO;

namespace Tracker.User.Service.Test
{
    [TestClass]
    public class UserServiceTest
    {
        private readonly IMapper mapperMock;
        private readonly IUserService userService;

        /// <summary>
        /// Construtor, configuring the mock objects and automapper
        /// </summary>
        public UserServiceTest()
        {
            // Mapper configuration
            var myProfile = new MapperProfile();
            var _config = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            mapperMock = new Mapper(_config);

            // Repository mock object and method setup.
            var userRepoMock = new Mock<IUserRepository>();
            var mockData = UserMockdata.AsQueryable().BuildMock();
            userRepoMock.Setup(x => x.FindByCondition(It.IsAny<Expression<Func<Tracker.User.Data.Models.User, bool>>>())).Returns(mockData.Object);
            userRepoMock.Setup(x => x.FindAll()).Returns(mockData.Object);
            userRepoMock.Setup(x => x.Create(It.IsAny<Tracker.User.Data.Models.User>())).Returns(Task.FromResult(this.UserMockdata.First()));
            userRepoMock.Setup(x => x.Update(It.IsAny<Tracker.User.Data.Models.User>()));
            userRepoMock.Setup(x => x.Delete(It.IsAny<Tracker.User.Data.Models.User>()));

            //The service instance.
            userService = new UserService(userRepoMock.Object, mapperMock);
        }

        [TestMethod]
        public async Task Call_Method_Create_Returns_Object()
        {
            var createdUser = await userService.Create(UserDTOMockdata.First());

            Assert.IsNotNull(createdUser);
            Assert.IsNotNull(createdUser.UserId);
        }

        [TestMethod]
        public void Call_Method_Update_Returns_Nothing()
        {
            // Making sure whether the update is called without any exceptions.
            try
            {
                this.userService.Update(this.UserDTOMockdata.First());
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Call_Method_Delete_Returns_Nothing()
        {
            // Making sure whether the delete is called without any erros.
            try
            {
                this.userService.Delete(this.UserDTOMockdata.First());
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task Call_Method_FetchAllUsers_Returns_List()
        {
            var users = await userService.FetchAllUsers();

            Assert.IsNotNull(users);
            Assert.AreEqual(1, users.Count());
        }

        /// <summary>
        /// The test User data.
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
                        Role = "Admin",
                        CreateBy = "Admin",
                        CreatedDate = DateTime.UtcNow
                  }
                };
            }
        }

        /// <summary>
        /// The test User DTO data.
        /// </summary>
        private List<UserDTO> UserDTOMockdata
        {
            get
            {
                return new List<UserDTO>()
                {
                  new UserDTO()
                  {
                        UserId = Guid.NewGuid(),
                        UserName = "test_user",
                        Password = "test_password",
                        Role = "Admin",
                        CreateBy = "Admin",
                        CreatedDate = DateTime.UtcNow
                  }
                };
            }
        }
    }
}
