using System;
using Xunit;

namespace Testing.Bank.Tests.CustomData
{
    public class TransactionShould
    {
        [Theory]
        [Csv("Data/TransactionData.csv")]
        public void TransactionCreationDeposit_ThrowsExceptions(int amount, string description)
        {
            Action action = () => { _ = new Transaction(TransactionType.Deposit, amount, description); };

            Assert.Throws<Exception>(action);
        }

        [Theory]
        [Csv("Data/TransactionData.csv")]
        public void TransactionCreationWithdraw_ThrowsExceptions(int amount, string description)
        {
            Action action = () => { _ = new Transaction(TransactionType.Withdraw, amount, description); };

            Assert.Throws<Exception>(action);
        }
    }
}