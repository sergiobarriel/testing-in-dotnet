using System;
using Xunit;

namespace Testing.Bank.Tests.CustomData
{
    public class UserShould
    {
        [Theory]
        [Csv("Data/UserData.csv")]
        public void UserCreation_ThrowsExceptions(string name, int age)
        {
            Action action = () => { _ = new User(name, age); };

            Assert.Throws<Exception>(action);
        }
    }
}