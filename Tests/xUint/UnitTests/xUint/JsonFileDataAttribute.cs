using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace System
{
    public class JsonFileDataAttribute : DataAttribute
    {
        private string _FileName;

        public JsonFileDataAttribute(string FileName)
        {
            _FileName = FileName;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            string jsonString = File.ReadAllText(_FileName);
            var data = new StringContent(jsonString, Encoding.UTF8, "application/json");
            yield return new object[] { data };
        }
    }
}
