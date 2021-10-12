using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit.Sdk;

namespace Testing.Bank.Tests.CustomData
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
            var parameters = testMethod.GetParameters();
            var parameterTypes = parameters.Select(parameterInfo => parameterInfo.ParameterType).ToArray();

            using var streamReader = new StreamReader(_file);

            string line;

            while ((line = streamReader.ReadLine()) != null)
            {
                var items = line.Split(",");

                var result = new object[parameterTypes.Length];

                for (var i = 0; i < parameterTypes.Length; i++)
                {
                    if(parameterTypes[i] is null)
                    {
                        result[i] = null;
                    }

                    if (parameterTypes[i] == typeof(string))
                    {
                        result[i] = items[i];
                    }

                    if (parameterTypes[i] == typeof(int))
                    {
                        if (items[i].Trim().Length > 0)
                        {
                            result[i] = Convert.ToInt32(items[i].Trim());
                        }
                    }

                    if (parameterTypes[i] == typeof(bool))
                    {
                        result[i] = Convert.ToBoolean(items[i].Trim());
                    }
                }

                yield return result;
            }
        }
    }
}
