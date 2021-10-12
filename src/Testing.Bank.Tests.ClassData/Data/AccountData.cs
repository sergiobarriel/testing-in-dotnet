using System.Collections;
using System.Collections.Generic;

namespace Testing.Bank.Tests.ClassData.Data
{
    public class AccountData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { -100 };
            yield return new object[] { 0 };
            yield return new object[] { null };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}