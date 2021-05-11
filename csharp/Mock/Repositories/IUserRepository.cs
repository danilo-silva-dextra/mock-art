using System.Collections.Generic;
using Mock.Models;

namespace Mock.Repositories
{
    public interface IUserRepository
    {
         IEnumerable<User> GetUsers();

         User GetUser(long id);

         User CreateUser(User user);

         User UpdateUser(User user, long id);

         void DeleteUser(long id);
    }
}