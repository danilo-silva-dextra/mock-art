using System.Linq;
using Mock.Services;
using Mock.Models;
using Mock.Controllers;
using Moq;
using Xunit;
using System.Collections.Generic;
using System.Web;
using System.Net;
using System.Net.Http;

namespace Mock.Test.Controllers
{
    public class UserControllerTest
    {
        [Fact]
        public void WhenGetUsers_ThenSuccess()
        {
            //Arrange
            IEnumerable<User> expected = this.CreateUserList();
            Moq.Mock<IUserService> mockUserService = new Moq.Mock<IUserService>();
            mockUserService.Setup(mock => mock.GetUsers()).Returns(expected);

            UserController injectedClass = new UserController(null, mockUserService.Object);

            //Act
            IEnumerable<User> actual = injectedClass.GetUsers();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenGetUsers_WithEmptyList_ThenThrowException()
        {
            //Arrange
            IEnumerable<User> expected = Enumerable.Empty<User>();
            Moq.Mock<IUserService> mockUserService = new Moq.Mock<IUserService>();
            mockUserService.Setup(mock => mock.GetUsers()).Returns(expected);

            UserController injectedClass = new UserController(null, mockUserService.Object);

            //Act Assert
            var ex = Assert.Throws<HttpRequestException>(() => injectedClass.GetUsers());
            Assert.Equal("Recurso vazio", ex.Message);
            Assert.Equal(HttpStatusCode.NoContent, ex.StatusCode);
        }

        public List<User> CreateUserList(){
            return new List<User>
            {
                new User
                {
                    Id = 1,
                    Name = "Danilo",
                    Age = 24
                },
                new User
                {
                    Id = 2,
                    Name = "Joãozinho",
                    Age = 45
                },
                new User
                {
                    Id = 3,
                    Name = "Mariazinha",
                    Age = 40
                },
            };
        }

    }
}