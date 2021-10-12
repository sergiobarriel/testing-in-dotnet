using System;
using System.Collections.Generic;
using Xunit;

namespace Testing.Bank.Tests.MemberData
{
    public class TransactionShould
    {
        private static string GetDescription() => "Description";

        public static IEnumerable<object[]> GetTransactionTheoryData() => new List<object[]>()
        {
            new object[] {TransactionType.Deposit, 100, string.Empty },
            new object[] {TransactionType.Deposit, 100, null },
            new object[] {TransactionType.Deposit, -100, GetDescription() },
            new object[] {TransactionType.Withdraw, -100, GetDescription() },
        };

        [Theory]
        [MemberData(nameof(GetTransactionTheoryData))]
        public void TransactionCreation_ThrowsExceptions(TransactionType type, int amount, string description)
        {
            Action action = () => { _ = new Transaction(type, amount, description); };

            Assert.Throws<Exception>(action);
        }
    }
}