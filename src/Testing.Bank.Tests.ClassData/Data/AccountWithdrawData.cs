using System.Collections;
using System.Collections.Generic;

namespace Testing.Bank.Tests.ClassData.Data
{
    public class AccountWithdrawData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 100, 200 };
            yield return new object[] { 0, 0 };
            yield return new object[] { 100, -100 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}