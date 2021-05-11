module.exports = () => {
  const User = 
    {
      id: DataTypes.Number,
      name: DataTypes.STRING,
      age: DataTypes.Number,
    }
  ;

  return User;
};
