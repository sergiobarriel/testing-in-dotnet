using System;
using Xunit;

namespace Testing.Bank.Tests.Theories
{
    public class UserShouldTheoryInlineData
    {
        [Theory]
        [InlineData("", 18, "Name is required")]
        [InlineData("Morty Smith", 14, "Age should be equal or greater than 18")]
        public void UserCreationTheoryInlineData_ThrowsExceptions(string name, int age, string expectedException)
        {
            Action action = () => { _ = new User(name, age); };

            var exception = Assert.Throws<Exception>(action);
            Assert.Equal(expectedException, exception.Message);
        }

    }
}