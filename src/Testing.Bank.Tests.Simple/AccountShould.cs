using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Testing.Bank.Tests.Simple
{
    public class AccountShould
    {
        private User GetUser() => new User("Rick Sánchez", 70);

        [Fact]
        public void AccountWithEmptyTransactions_GenerateInstance()
        {
            // Arrange
            var transactions = new List<Transaction>();

            // Act
            var account = new Account(GetUser(), transactions);
            var balance = account.GetBalance();

            // Assert
            Assert.Equal(0, balance);
        }

        [Fact]
        public void AccountWithNullTransactions_GenerateInstance()
        {
            // Arrange

            // Act
            Action action = () => { _ = new Account(GetUser(), null); };

            // Assert
            var exception = Assert.Throws<Exception>(action);
        }

        [Fact]
        public void AccountWithDepositTransactions_CalculatesBalance()
        {
            // Arrange
            var transactions = new List<Transaction>()
            {
                new Transaction(TransactionType.Deposit, 10, "Deposit 10 €"),
                new Transaction(TransactionType.Deposit, 10, "Deposit 10 €"),
                new Transaction(TransactionType.Deposit, 10, "Deposit 10 €"),
            };

            // Act
            var account = new Account(GetUser(), transactions);
            var balance = account.GetBalance();

            // Assert
            Assert.Equal(30, balance);
        }

        [Fact]
        public void AccountWithWithdrawTransactions_CalculatesBalance()
        {
            // Arrange
            var transactions = new List<Transaction>()
            {
                new Transaction(TransactionType.Withdraw, 10, "Withdraw 10 €"),
                new Transaction(TransactionType.Withdraw, 10, "Withdraw 10 €"),
                new Transaction(TransactionType.Withdraw, 10, "Withdraw 10 €"),
            };

            // Act
            var account = new Account(GetUser(), transactions);
            var balance = account.GetBalance();

            // Assert
            Assert.Equal(-30, balance);
        }


        [Fact]
        public void AccountWithDepositAndWithdrawTransactions_CalculatesBalance()
        {
            // Arrange
            var transactions = new List<Transaction>()
            {
                new Transaction(TransactionType.Deposit, 10, "Deposit 10 €"),
                new Transaction(TransactionType.Deposit, 10, "Deposit 10 €"),
                new Transaction(TransactionType.Deposit, 10, "Deposit 10 €"),
                new Transaction(TransactionType.Withdraw, 10, "Withdraw 10 €"),
                new Transaction(TransactionType.Withdraw, 10, "Withdraw 10 €"),
                new Transaction(TransactionType.Withdraw, 10, "Withdraw 10 €"),
            };

            // Act
            var account = new Account(GetUser(), transactions);
            var balance = account.GetBalance();

            // Assert
            Assert.Equal(0, balance);
        }

        [Fact]
        public void AccountWithdraw_ReducesBalance()
        {
            // Arrange
            var transactions = new List<Transaction>()
            {
                new Transaction(TransactionType.Deposit, 10, "Deposit 10 €"),
                new Transaction(TransactionType.Deposit, 10, "Deposit 10 €"),
                new Transaction(TransactionType.Deposit, 10, "Deposit 10 €"),
            };

            // Act
            var account = new Account(GetUser(), transactions);
            
            account.Withdraw(10, "Withdraw 10 €");

            var balance = account.GetBalance();

            // Assert
            Assert.Equal(20, balance);
        }


        [Fact]
        public void AccountDeposit_IncreasesBalance()
        {
            // Arrange
            var transactions = new List<Transaction>()
            {
                new Transaction(TransactionType.Deposit, 10, "Deposit 10 €"),
                new Transaction(TransactionType.Deposit, 10, "Deposit 10 €"),
                new Transaction(TransactionType.Deposit, 10, "Deposit 10 €"),
            };

            // Act
            var account = new Account(GetUser(), transactions);

            account.Deposit(10, "Deposit 10 €");

            var balance = account.GetBalance();

            // Assert
            Assert.Equal(40, balance);
        }

        [Fact]
        public void AccountInZero_CantWithdraw()
        {
            // Arrange
            var transactions = new List<Transaction>()
            {
                new Transaction(TransactionType.Withdraw, 10, "Deposit 10 €"),
                new Transaction(TransactionType.Withdraw, 10, "Deposit 10 €"),
                new Transaction(TransactionType.Withdraw, 10, "Deposit 10 €"),
            };

            // Act
            var account = new Account(GetUser(), transactions);

            Action action = () => { account.Withdraw(10, "Withdraw 10 €"); };

            // Assert
            Assert.Throws<Exception>(action);
        }
    }
}
