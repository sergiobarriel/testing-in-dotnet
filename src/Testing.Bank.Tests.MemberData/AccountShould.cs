using System;
using System.Collections.Generic;
using Xunit;

namespace Testing.Bank.Tests.MemberData
{
    public class AccountShould
    {
        private static User GetUser() => new User("Rick Sánchez", 70);

        public static IEnumerable<object[]> GetAccountTheoryData() => new List<object[]>()
        {
            new object[] { GetUser(), -100 },
            new object[] { GetUser(), 0 },
            new object[] { null, 100 },
        };

        public static IEnumerable<object[]> GetWithdrawTheoryData() => new List<object[]>()
        {
            new object[] { GetUser(), 100, 200 },
            new object[] { GetUser(), 0, 0 },
            new object[] { GetUser(), 100, -100 },
        };

        public static IEnumerable<object[]> GetDepositTheoryData() => new List<object[]>()
        {
            new object[] { GetUser(), 0, 0 },
            new object[] { GetUser(), 100, -100 },
        };


        [Theory]
        [MemberData(nameof(GetAccountTheoryData))]
        public void AccountCreation_ThrowsExceptions(User user, int balance)
        {
            Action action = () => { _ = new Account(user, balance); };

            Assert.Throws<Exception>(action);
        }

        [Theory]
        [MemberData(nameof(GetWithdrawTheoryData))]
        public void AccountWithdraw_ThrowsExceptions(User user, int balance, int amount)
        {
            Action action = () =>
            {
                var account = new Account(user, balance);

                account.Withdraw(amount);
            };

            Assert.Throws<Exception>(action);
        }

        [Theory]
        [MemberData(nameof(GetDepositTheoryData))]
        public void AccountDeposit_ThrowsExceptions(User user, int balance, int amount)
        {
            Action action = () =>
            {
                var account = new Account(user, balance);

                account.Deposit(amount);
            };

            Assert.Throws<Exception>(action);
        }

    }
}