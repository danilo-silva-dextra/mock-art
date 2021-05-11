using System.Collections.Generic;
using Mock.Models;

namespace Mock.Services
{
    public interface IUserService
    {
         IEnumerable<User> GetUsers();

         User GetUser(long id);

         User CreateUser(User user);

         User UpdateUser(User user, long id);

         void DeleteUser(long id);
    }
}