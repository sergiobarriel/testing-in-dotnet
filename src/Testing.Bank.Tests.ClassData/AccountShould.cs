using System;
using Testing.Bank.Tests.ClassData.Data;
using Xunit;

namespace Testing.Bank.Tests.ClassData
{
    public class AccountShould
    {
        private User GetUser() => new User("Rick Sánchez", 70);

        [Theory]
        [ClassData(typeof(AccountData))]
        public void AccountCreation_ThrowsExceptions(int balance)
        {
            Action action = () => { _ = new Account(GetUser(), balance); };

            Assert.Throws<Exception>(action);
        }


        [Theory]
        [ClassData(typeof(AccountWithdrawData))]
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
        [ClassData(typeof(AccountDepositData))]
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