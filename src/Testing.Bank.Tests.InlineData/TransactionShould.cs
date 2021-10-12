using System;
using Xunit;

namespace Testing.Bank.Tests.InlineData
{
    public class TransactionShould
    {
        [Theory]
        [InlineData(TransactionType.Deposit, 100, "")]
        [InlineData(TransactionType.Deposit, 100, null)]
        [InlineData(TransactionType.Deposit, -100, "Description")]
        [InlineData(TransactionType.Withdraw, -100, "Description")]
        public void TransactionCreation_ThrowsExceptions(TransactionType type, int amount, string description)
        {
            Action action = () => { _ = new Transaction(type, amount, description); };

            Assert.Throws<Exception>(action);
        }
    }
}