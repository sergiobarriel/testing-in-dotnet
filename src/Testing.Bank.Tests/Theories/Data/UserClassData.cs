using System.Collections;
using System.Collections.Generic;

namespace Testing.Bank.Tests.Theories.Data
{
    public class UserClassData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "", 18, $"{nameof(User.Name)} is required" };
            yield return new object[] { "Morty Smith", 14, $"{nameof(User.Age)} should be equal or greater than 18" };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}