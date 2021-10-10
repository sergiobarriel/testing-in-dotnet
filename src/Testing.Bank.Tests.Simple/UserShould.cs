using System;
using Xunit;

namespace Testing.Bank.Tests
{
    public class UserShould
    {
        [Fact]
        public void UserWithoutName_ThrowsException()
        {
            // Arrange
            var name = string.Empty;
            var age = 18;

            // Act
            Action action = () => { _ = new User(name, age); };

            // Assert
            var exception = Assert.Throws<Exception>(action);
            Assert.Equal($"{nameof(User.Name)} is required", exception.Message);
        }

        [Fact]
        public void YoungerUser_ThrowsException()
        {
            // Arrange
            var name = "Morty Smith";
            var age = 14;

            // Act
            Action action = () => { _ = new User(name, age); };

            // Assert
            var exception = Assert.Throws<Exception>(action);
            Assert.Equal($"{nameof(User.Age)} should be equal or greater than 18", exception.Message);
        }

        [Fact]
        public void UserWithRightParameters_GenerateInstance()
        {
            // Arrange
            var name = "Summer Smith";
            var age = 18;

            // Act
            var user = new User(name, age);

            // Assert
            Assert.Equal(name, user.Name);
            Assert.Equal(age, user.Age);
        }
    }
}