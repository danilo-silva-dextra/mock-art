using System;
using System.Linq;
using System.Collections.Generic;
using Mock.Models;
using Mock.Repositories;

namespace Mock.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public User GetUser(long id)
        {
            return _userRepository.GetUser(id);
        }

        public User CreateUser(User user)
        {
            int age = user.Age;

            if (age < 18) {
                throw new ApplicationException("Cadastro inválido, usuário tem menos de 18 anos");
            
            } else if (age > 75) {
                throw new ApplicationException("Cadastro inválido, usuário tem mais de 75 anos");

            }

            return _userRepository.CreateUser(user);
        }

        public User UpdateUser(User user, long id)
        {
            return _userRepository.UpdateUser(user, id);
        }

        public void DeleteUser(long id)
        {
            _userRepository.DeleteUser(id);
        }
    }
}