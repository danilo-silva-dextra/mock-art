const assert = require('assert');

const UserController = require('../../src/controller/UserController')

describe('Get All User Controller', () => {
  
  it('when get users, then success', () => {
    //Arrange
    const expected = createUserList();

    const mockService = {
        getAll() {
            return expected;
        }
    }

    const userController = new UserController(mockService);

    //Exec
    const actual = userController.getAll();
    
    //Assert
    assert.strictEqual(actual, expected)
  })
  
  it('when get users, with empty list, then throw exception', () => {
    //Arrange
    const list = [];

    const mockService = {
        getAll() {
            return list;
        }
    }

    //Exec
    const userController = new UserController(mockService);
    
    //Assert
    assert.throws(
        () => {
            userController.getAll();
        }, {
            message: 'Recurso vazio',
            name: 'HttpException',
            code: 204
        }
    )
  })
})

function createUserList(){
    return [{
        id: 1,
        name: 'Danilo',
        age: 24
    },{
        id: 2,
        name: 'Carlinhos',
        age: 33
    },{
        id: 3,
        name: 'Joaninha',
        age: 22
    }]
}