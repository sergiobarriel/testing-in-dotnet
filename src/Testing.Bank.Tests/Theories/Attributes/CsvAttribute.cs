using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Testing.Bank.Tests.Theories.Attributes
{
    public class CsvAttribute : DataAttribute
    {
        private readonly string _file;

        public CsvAttribute(string file)
        {
            _file = file;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            using var file = new StreamReader(_file);

            var line = string.Empty;

            while ((line = file.ReadLine()) != null)
            {
                var items = line.Split(",");
            }

            return new List<object[]>();
        }
    }
}
