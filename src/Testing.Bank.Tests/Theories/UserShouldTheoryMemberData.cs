using System;
using System.Collections.Generic;
using Xunit;

namespace Testing.Bank.Tests.Theories
{
    public class UserShouldTheoryMemberData
    {
        public static IEnumerable<object[]> GetUserMemberData() => new List<object[]>()
        {
            new object[] {"", 18, $"{nameof(User.Name)} is required"},
            new object[] {"Morty Smith", 14, $"{nameof(User.Age)} should be equal or greater than 18"},
        };


        [Theory]
        [MemberData(nameof(GetUserMemberData))]
        public void UserCreationTheoryMemberData_ThrowsExceptions(string name, int age, string expectedException)
        {
            Action action = () => { _ = new User(name, age); };

            var exception = Assert.Throws<Exception>(action);
            Assert.Equal(expectedException, exception.Message);
        }



    }
}