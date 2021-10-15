using System;
using System.Collections.Generic;
using Xunit;

namespace Testing.Bank.Tests.MemberData
{
    public class AccountShould
    {
        private static User GetUser() => new User("Rick Sánchez", 70);

        private IList<Transaction> Transactions => new List<Transaction>()
        {
            new Transaction(TransactionType.Deposit, 10, "Deposit 10 €"),
            new Transaction(TransactionType.Deposit, 10, "Deposit 10 €"),
            new Transaction(TransactionType.Deposit, 10, "Deposit 10 €"),
            new Transaction(TransactionType.Withdraw, 10, "Withdraw 10 €"),
        };

        public static IEnumerable<object[]> GetWithdrawTheoryData() => new List<object[]>()
        {
            new object[] { GetUser(), 100000 },
            new object[] { GetUser(), 0 },
            new object[] { GetUser(), -100 },
        };

        public static IEnumerable<object[]> GetDepositTheoryData() => new List<object[]>()
        {
            new object[] { GetUser(), 0 },
            new object[] { GetUser(), -100 },
        };


        [Theory]
        [MemberData(nameof(GetWithdrawTheoryData))]
        public void AccountWithdraw_ThrowsExceptions(User user, int amount)
        {
            Action action = () =>
            {
                var account = new Account(user, Transactions);

                account.Withdraw(amount, $"Withdraw {amount} $");
            };

            Assert.Throws<Exception>(action);
        }

        [Theory]
        [MemberData(nameof(GetDepositTheoryData))]
        public void AccountDeposit_ThrowsExceptions(User user, int amount)
        {
            Action action = () =>
            {
                var account = new Account(user, Transactions);

                account.Deposit(amount, $"Deposit {amount} $");
            };

            Assert.Throws<Exception>(action);
        }

    }
}