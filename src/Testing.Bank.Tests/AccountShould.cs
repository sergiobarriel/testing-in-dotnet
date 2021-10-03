using System;
using Xunit;

namespace Testing.Bank.Tests
{
    public class AccountShould
    {
        private User GetUser() => new User("Rick Sánchez", 70);

        [Fact]
        public void AccountWithLessThanZeroBalance_ThrowsException()
        {
            // Arrange
            var balance = -5;

            // Act
            Action action = () => { _ = new Account(GetUser(), balance); };

            // Assert
            var exception = Assert.Throws<Exception>(action);
            Assert.Equal($"{nameof(Account.Balance)} should be greater than zero", exception.Message);

        }

        [Fact]
        public void AccountWithZeroBalance_ThrowsException()
        {
            // Arrange
            var balance = 0;

            // Act
            Action action = () => { _ = new Account(GetUser(), balance); };

            // Assert
            var exception = Assert.Throws<Exception>(action);
            Assert.Equal($"{nameof(Account.Balance)} should be greater than zero", exception.Message);

        }

        [Fact]
        public void AccountWithRightParameters_GenerateInstance()
        {
            // Arrange
            var balance = 10;

            // Act
            var account = new Account(GetUser(), balance);

            // Assert
            Assert.Equal(balance, account.Balance);
        }

        [Fact]
        public void LessThanZeroDeposit_ThrowsException()
        {
            // Arrange
            var account = new Account(GetUser(), 100);

            // Act
            Action action = () =>
            {
                account.Deposit(-10);
            };

            // Assert
            Assert.Throws<Exception>(action);
        }

        [Fact]
        public void LessThanZeroWithdraw_ThrowsException()
        {
            // Arrange
            var account = new Account(GetUser(), 100);

            // Act
            Action action = () =>
            {
                account.Withdraw(-10);
            };

            // Assert
            Assert.Throws<Exception>(action);
        }

        [Fact]
        public void Deposit_IncreaseBalance()
        {
            // Arrange
            var account = new Account(GetUser(), 100);

            // Act
            account.Deposit(10);

            // Assert
            Assert.Equal(110, account.Balance);
            Assert.True(account.Balance > 100);
        }

        [Fact]
        public void Withdraw_ReduceBalance()
        {
            // Arrange
            var account = new Account(GetUser(), 100);

            // Act
            account.Withdraw(10);

            // Assert
            Assert.Equal(90, account.Balance);
            Assert.True(account.Balance < 100);
        }

        [Fact]
        public void WithdrawGreaterThanBalance_ThrowsException()
        {
            // Arrange
            var account = new Account(GetUser(), 100);

            // Act
            Action action = () =>
            {
                account.Withdraw(200);
            };

            // Assert
            Assert.Throws<Exception>(action);

        }
    }
}
