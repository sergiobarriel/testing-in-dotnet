﻿using System;
using Xunit;

namespace Testing.Bank.Tests.Fixtures
{

    [Collection("account-collection-fixture-should")]
    public class AccountCollectionFixtureShould
    {
        private readonly AccountFixture _fixture;

        public AccountCollectionFixtureShould(AccountFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void AccountDeposit_ReturnsRightBalance()
        {
            // Arrange
            var startingBalance = _fixture.Account.GetBalance();
            var amount = 50;

            // Act 
            _fixture.Account.Deposit(amount, "Deposit {amount} $");

            // Assert
            Assert.Equal(startingBalance + amount, _fixture.Account.GetBalance());
        }

        [Fact]
        public void AccountWithdrawAll_ReturnsZeroBalance()
        {
            // Arrange
            var startingBalance = _fixture.Account.GetBalance();
            var amount = startingBalance;

            // Act 
            _fixture.Account.Withdraw(amount, "Total withdraw {amount} $");

            // Assert
            Assert.Equal(0, _fixture.Account.GetBalance());
        }

        [Fact]
        public void AccountExcessiveWithdrawal_ThrowsException()
        {
            // Arrange
            var startingBalance = _fixture.Account.GetBalance();
            var amount = startingBalance;

            // Act
            Action action = () =>
            {
                _fixture.Account.Withdraw(amount + 1, "Excessive withdraw {amount} $");
            };

            // Assert
            Assert.Throws<Exception>(action);
        }
    }
}