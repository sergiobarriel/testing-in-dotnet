using System;
using Testing.Bank.Tests.Theories.Attributes;
using Xunit;

namespace Testing.Bank.Tests.Theories
{
    public class UserShouldCustomData
    {
        [Theory]
        [Csv("UserData.csv")]
        public void UserCreationTheoryMemberData_ThrowsExceptions(string name, int age, string expectedException)
        {
            Action action = () => { _ = new User(name, age); };

            var exception = Assert.Throws<Exception>(action);
            Assert.Equal(expectedException, exception.Message);
        }

    }
}