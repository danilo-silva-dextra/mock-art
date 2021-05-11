const assert = require("assert");
const sinon = require("sinon");

const UserService = require("../../src/service/UserService");
const UserRepository = require("../../src/repository/UserRepository");

describe("Create User Service", () => {
  it("when create user, then success", () => {
    //Arrange
    const expected = createUser();
    expected.age = 24;

    const mockRepository = {
      create(expected) {
        return expected;
      },
    };

    const userService = new UserService(mockRepository);

    //Exec
    const actual = userService.create(expected);

    //Assert
    assert.strictEqual(actual, expected);
  });

  it("when create user, with age less than 18, then throw exception", () => {
    //Arrange
    const expected = createUser();
    expected.age = 15;

    const mockRepository = {
      create(expected) {
        return expected;
      },
    };
    const userService = new UserService(mockRepository);

    //Exec
    //Assert
    assert.throws(
      () => {
        userService.create(expected);
      },
      {
        message: "Cadastro inválido, usuário tem menos de 18 anos",
        name: "ApplicationException",
        code: 400,
      }
    );
  });

  it("when create user, with age more than 75, then throw exception", () => {
    //Arrange
    const expected = createUser();
    expected.age = 88;

    const mockRepository = {
      create(expected) {
        return expected;
      },
    };

    const userService = new UserService(mockRepository);

    //Exec
    //Assert
    assert.throws(
      () => {
        userService.create(expected);
      },
      {
        message: "Cadastro inválido, usuário tem mais de 75 anos",
        name: "ApplicationException",
        code: 400,
      }
    );
  });
});

describe("Delete User Service", () => {
  it("when delete user, then success", () => {
    //Arrange
    const id = 1;

    const mockRepository = sinon.mock(UserRepository);
    mockRepository.expects("existsById").once().withArgs(id).returns(true);
    mockRepository.expects("deleteById").once().withArgs(id);

    const userService = new UserService(UserRepository);

    //Exec
    userService.deleteById(id);

    //Assert
    mockRepository.verify();
  });

  it("when create user, with non-existent id, then throw exception", () => {
    //Arrange
    const id = 1;

    const mockRepository = sinon.mock(UserRepository);
    mockRepository.expects("existsById").once().withArgs(id).returns(false);

    const userService = new UserService(UserRepository);

    //Exec
    //Assert
    mockRepository.expects("deleteById").never().withArgs(id);

    assert.throws(
      () => {
        userService.deleteById(id);
      },
      {
        message: "Id do recurso não existente",
        name: "NotFoundException",
        code: 404,
      }
    );

    mockRepository.verify();
  });
});

function createUser() {
  return {
    id: 1,
    name: "Danilo",
    age: 24,
  };
}
