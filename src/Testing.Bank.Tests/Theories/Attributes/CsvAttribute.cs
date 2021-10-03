using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Testing.Bank.Tests.Theories.Attributes
{
    public class CsvAttribute : DataAttribute
    {
        public CsvAttribute()
        {
            
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            throw new NotImplementedException();
        }
    }
}
