using System;
using Xunit;

namespace Testing.Bank.Tests.InlineData
{
    public class UserShould
    {

        [Theory]
        [InlineData("", 18)]
        [InlineData(null, 18)]
        [InlineData("Morty Smith", 14)]
        [InlineData("Morty Smith", 0)]
        [InlineData("Morty Smith", -10)]
        [InlineData("Morty Smith", null)]
        public void UserCreation_ThrowsExceptions(string name, int age)
        {
            Action action = () => { _ = new User(name, age); };

            Assert.Throws<Exception>(action);
        }

    }
}