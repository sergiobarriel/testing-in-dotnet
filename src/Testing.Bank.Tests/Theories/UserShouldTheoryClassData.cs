using System;
using Testing.Bank.Tests.Theories.Data;
using Xunit;

namespace Testing.Bank.Tests.Theories
{
    public class UserShouldTheoryClassData
    {
        [Theory]
        [ClassData(typeof(UserClassData))]
        public void UserCreationTheoryClassData_ThrowsExceptions(string name, int age, string expectedException)
        {
            Action action = () => { _ = new User(name, age); };

            var exception = Assert.Throws<Exception>(action);
            Assert.Equal(expectedException, exception.Message);
        }

    }
}