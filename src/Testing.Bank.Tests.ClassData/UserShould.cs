using System;
using Testing.Bank.Tests.ClassData.Data;
using Xunit;

namespace Testing.Bank.Tests.ClassData
{
    public class UserShould
    {
        [Theory]
        [ClassData(typeof(UserData))]
        public void UserCreation_ThrowsExceptions(string name, int age)
        {
            Action action = () => { _ = new User(name, age); };

            Assert.Throws<Exception>(action);
        }
    }
}