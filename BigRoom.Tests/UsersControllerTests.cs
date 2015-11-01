using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigRoom.BusinessLayer.Interfaces;
using BigRoom.Model;
using BigRoom.Service.Controllers.API;
using BigRoom.Service.Models.UserVms;
using NSubstitute;
using NUnit.Framework;

namespace BigRoom.Tests
{
    [TestFixture]
    public class UsersControllerTests
    {
        [Test]
        public void GetUser_WhenCalled_ReturnsUser()
        {
            // Arrange
            const int id = 1;
            User user = new User
            {
                Id = 1,
                Name = "Jovan",
                Email = "example@example.com",
                IsAdmin = true
            };
            IUserService fakeUserService = Substitute.For<IUserService>();
            fakeUserService.FindUser(id).Returns(user);

            //Act
            UsersController usersController = new UsersController(fakeUserService);
            UserVM result = usersController.Get(id);

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
