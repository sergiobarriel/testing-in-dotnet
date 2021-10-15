using System;
using System.Collections.Generic;
using Xunit;

namespace Testing.Bank.Tests.InlineData
{
    public class AccountShould
    {
        private User GetUser() => new User("Rick Sánchez", 70);

        private IList<Transaction> Transactions => new List<Transaction>()
        {
            new Transaction(TransactionType.Deposit, 10, "Deposit 10 €"),
            new Transaction(TransactionType.Deposit, 10, "Deposit 10 €"),
            new Transaction(TransactionType.Deposit, 10, "Deposit 10 €"),
            new Transaction(TransactionType.Withdraw, 10, "Withdraw 10 €"),
        };

        [Theory]
        [InlineData(0)]
        [InlineData(-100)]
        [InlineData(1000000)]
        public void AccountWithdraw_ThrowsExceptions(int amount)
        {
            Action action = () =>
            {
                var account = new Account(GetUser(), Transactions);

                account.Withdraw(amount, $"Withdraw {amount} $");
            };

            Assert.Throws<Exception>(action);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-100)]
        public void AccountDeposit_ThrowsExceptions(int amount)
        {
            Action action = () =>
            {
                var account = new Account(GetUser(), Transactions);

                account.Deposit(amount, $"Deposit {amount} $");
            };

            Assert.Throws<Exception>(action);
        }
    }


}