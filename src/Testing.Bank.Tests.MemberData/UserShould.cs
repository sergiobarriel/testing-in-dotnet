using System;
using System.Collections.Generic;
using Xunit;

namespace Testing.Bank.Tests.MemberData
{
    public class UserShould
    {
        private static string GetName() => "Morty Smith";

        public static IEnumerable<object[]> GetUserTheoryData() => new List<object[]>()
        {
            new object[] { string.Empty, 18 },
            new object[] { null, 18 },
            new object[] { GetName(), 14 },
            new object[] { GetName(), 0 },
            new object[] { GetName(), -10 },
            new object[] { GetName(), null },
        };

        [Theory]
        [MemberData(nameof(GetUserTheoryData))]
        public void UserCreation_ThrowsExceptions(string name, int age)
        {
            Action action = () => { _ = new User(name, age); };

            Assert.Throws<Exception>(action);
        }
    }
}