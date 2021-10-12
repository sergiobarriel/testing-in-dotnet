using System.Collections;
using System.Collections.Generic;

namespace Testing.Bank.Tests.ClassData.Data
{
    public class TransactionData : IEnumerable<object[]>
    {
        private string GetDescription() => "Description";

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { TransactionType.Deposit, 100, "" };
            yield return new object[] { TransactionType.Deposit, 100, null };
            yield return new object[] { TransactionType.Deposit, -100, GetDescription() };
            yield return new object[] { TransactionType.Withdraw, -100, GetDescription() };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}