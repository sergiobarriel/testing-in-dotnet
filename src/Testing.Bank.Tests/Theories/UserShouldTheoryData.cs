using System;
using Testing.Bank.Tests.Theories.Factories;
using Xunit;

namespace Testing.Bank.Tests.Theories
{
    public class UserShouldTheoryData
    {
        [Theory]
        [ClassData(typeof(UserTheoryData))]
        public void UserCreationTheoryData_ThrowsExceptions(string name, int age, string expectedException)
        {
            Action action = () => { _ = new User(name, age); };

            var exception = Assert.Throws<Exception>(action);
            Assert.Equal(expectedException, exception.Message);
        }

    }
}