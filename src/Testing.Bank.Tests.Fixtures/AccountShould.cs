using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testing.Bank.Tests.Fixtures
{
    public class AccountShould : IClassFixture<AccountFixture>
    {
        private readonly AccountFixture _accountFixture;

        public AccountShould(AccountFixture accountFixture)
        {
            _accountFixture = accountFixture;
        }


        [Fact]
        public void AccountDeposit_ReturnsRightBalance()
        {
            // Arrange
            var startingBalance = _accountFixture.Account.GetBalance();
            var amount = 50;

            // Act 
            _accountFixture.Account.Deposit(amount, "Deposit {amount} $");

            // Assert
            Assert.Equal(startingBalance + amount, _accountFixture.Account.GetBalance());
        }

        [Fact]
        public void AccountWithdrawAll_ReturnsZeroBalance()
        {
            // Arrange
            var startingBalance = _accountFixture.Account.GetBalance();
            var amount = startingBalance;

            // Act 
            _accountFixture.Account.Withdraw(amount, "Total withdraw {amount} $");

            // Assert
            Assert.Equal(0, _accountFixture.Account.GetBalance());
        }

        [Fact]
        public void AccountExcessiveWithdrawal_ThrowsException()
        {
            // Arrange
            var startingBalance = _accountFixture.Account.GetBalance();
            var amount = startingBalance;

            // Act
            Action action = () =>
            {
                _accountFixture.Account.Withdraw(amount + 1, "Excessive withdraw {amount} $");
            };

            // Assert
            Assert.Throws<Exception>(action);
        }
    }
}
