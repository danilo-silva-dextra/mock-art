const UserRepository = require('../repository/UserRepository');

class UserService {

  constructor(UserRepository){
    this.userRepository = UserRepository;
  }

  create(user) { 
    const age = user.age;
  
    if (age < 18) {
        throw new ApplicationException("Cadastro inválido, usuário tem menos de 18 anos");
    
    } else if (age > 75) {
        throw new ApplicationException("Cadastro inválido, usuário tem mais de 75 anos");
  
    }
  
    return this.userRepository.create(user);
  }
  
  getAll() {
    return this.userRepository.getAll();
  }
  
  getById(id) { 
    return this.userRepository.getById(id);
  }
  
  update(user, id) { 
    return this.userRepository.update(user, id);
  }
  
  deleteById(id) { 
    if (this.userRepository.existsById(id)) {
      this.userRepository.deleteById(id);

    } else {
      throw new NotFoundException("Id do recurso não existente");
    }
  }
}
  
function ApplicationException(message) {
  this.message = message;
  this.name = "ApplicationException";
  this.code = 400;
}
  
function NotFoundException(message) {
  this.message = message;
  this.name = "NotFoundException";
  this.code = 404;
}

module.exports = UserService;