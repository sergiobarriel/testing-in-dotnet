using System;
using Xunit;

namespace Testing.Bank.Tests.InlineData
{
    public class AccountShould
    {
        private User GetUser() => new User("Rick Sánchez", 70);

        [Theory]
        [InlineData(-100)]
        [InlineData(0)]
        [InlineData(null)]
        public void AccountCreation_ThrowsException(int balance)
        {
            Action action = () => { _ = new Account(GetUser(), balance); };

            Assert.Throws<Exception>(action);
        }

        [Theory]
        [InlineData(100, 200)]
        [InlineData(0, 0)]
        [InlineData(100, -100)]
        public void AccountWithdraw_ThrowsExceptions(int balance, int amount)
        {
            Action action = () =>
            {
                var account = new Account(GetUser(), balance);

                account.Withdraw(amount);
            };

            Assert.Throws<Exception>(action);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(100, -100)]
        public void AccountDeposit_ThrowsExceptions(int balance, int amount)
        {
            Action action = () =>
            {
                var account = new Account(GetUser(), balance);

                account.Deposit(amount);
            };

            Assert.Throws<Exception>(action);
        }
    }


}