using System.Linq;
using System.Collections.Generic;
using Mock.Models;
using Mock.Repositories;

namespace Mock.Repositories
{
    public class UserRepository : IUserRepository
    {
        public IEnumerable<User> GetUsers()
        {
            return Enumerable.Empty<User>();
        }

        public User GetUser(long id)
        {
            return new User
            {
                Id = id,
                Name = "Danilo",
                Age = 22
            };
        }

        public User CreateUser(User user)
        {
            return user;
        }

        public User UpdateUser(User user, long id)
        {
            return user;
        }

        public void DeleteUser(long id)
        {
        }
    }
}