const UserService = require('../service/UserService');

class UserController {
  constructor(UserService){
    this.userService = UserService;
  }

  create(user) { 
    return this.userService.create(user);
  }
  
  getAll() {
    var list = this.userService.getAll();
    
    if(list.length < 1){
      throw new HttpException("Recurso vazio", 204)
    }
  
    return list;
  }
  
  getById(id) { 
    return this.userService.getById(id);
  }
  
  update(user, id) { 
    return this.userService.update(user, id);
  }
  
  deleteById(id) { 
    this.userService.deleteById(id);
  }
}

function HttpException(message, code) {
  this.message = message;
  this.name = "HttpException";
  this.code = code;
}

module.exports = UserController;