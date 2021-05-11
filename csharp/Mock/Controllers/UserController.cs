using System.Net;
using System.Net.Http;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mock.Models;
using Mock.Services;

namespace Mock.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            IEnumerable<User> list = _userService.GetUsers();
            
            if (list.Count() < 1) {
                throw new HttpRequestException("Recurso vazio", null, HttpStatusCode.NoContent);
            }

            return _userService.GetUsers();
        }

        [HttpGet("{id}")]
        public User GetUser(long id)
        {
            return _userService.GetUser(id);
        }

        [HttpPost]
        public User CreateUser(User user)
        {
            return _userService.CreateUser(user);
        }

        [HttpPut("{id}")]
        public User UpdateUser(User user, long id)
        {
            return _userService.UpdateUser(user, id);
        }

        [HttpDelete]
        public void DeleteUser(long id)
        {
            _userService.DeleteUser(id);
        }
    }
}
