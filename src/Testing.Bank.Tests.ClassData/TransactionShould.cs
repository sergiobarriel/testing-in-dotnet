using System;
using Testing.Bank.Tests.ClassData.Data;
using Xunit;

namespace Testing.Bank.Tests.ClassData
{
    public class TransactionShould
    {
        [Theory]
        [ClassData(typeof(TransactionData))]
        public void TransactionCreation_ThrowsExceptions(TransactionType type, int amount, string description)
        {
            Action action = () => { _ = new Transaction(type, amount, description); };

            Assert.Throws<Exception>(action);
        }
    }
}