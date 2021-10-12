using System.Collections;
using System.Collections.Generic;

namespace Testing.Bank.Tests.ClassData.Data
{
    public class UserData : IEnumerable<object[]>
    {
        private string GetName() => "Morty Smith";

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { null, 18 };
            yield return new object[] { GetName(), 14 };
            yield return new object[] { GetName(), 0 };
            yield return new object[] { GetName(), -10 };
            yield return new object[] { GetName(), null };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}