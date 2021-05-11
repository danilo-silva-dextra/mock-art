using System.Collections.Generic;
using System.Linq;
using System.Net;
using System;
using System.Net.Http;
using System.Web;
using Mock.Controllers;
using Mock.Models;
using Mock.Repositories;
using Mock.Services;
using Moq;
using Xunit;

namespace Mock.Test.Services
{
    public class UserServiceTest
    {
        [Fact]
        public void WhenCreateUser_ThenSuccess()
        {
            //Arrange
            User expected = this.CreateUser();
            expected.Age = 30;

            Moq.Mock<IUserRepository> mockUserRepository = new Moq.Mock<IUserRepository>();
            mockUserRepository.Setup(mock => mock.CreateUser(expected)).Returns(expected);

            UserService injectedClass = new UserService(mockUserRepository.Object);

            //Act
            User actual = injectedClass.CreateUser(expected);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenCreateUser_WithAgeLessThan18_ThenThrowException()
        {
            //Arrange
            User expected = this.CreateUser();
            expected.Age = 15;

            Moq.Mock<IUserRepository> mockUserRepository = new Moq.Mock<IUserRepository>();

            UserService injectedClass = new UserService(mockUserRepository.Object);

            //Act Assert
            var ex = Assert.Throws<ApplicationException>(() => injectedClass.CreateUser(expected));
            Assert.Equal("Cadastro inválido, usuário tem menos de 18 anos", ex.Message);
        }

        [Fact]
        public void WhenCreateUser_WithAgeMoreThan75_ThenThrowException()
        {
            //Arrange
            User expected = this.CreateUser();
            expected.Age = 99;

            Moq.Mock<IUserRepository> mockUserRepository = new Moq.Mock<IUserRepository>();

            UserService injectedClass = new UserService(mockUserRepository.Object);

            //Act Assert
            var ex = Assert.Throws<ApplicationException>(() => injectedClass.CreateUser(expected));
            Assert.Equal("Cadastro inválido, usuário tem mais de 75 anos", ex.Message);
        }

        public User CreateUser()
        {
            return new User
            {
                Id = 1,
                Name = "Danilo",
                Age = 24
            };
        }

    }
}