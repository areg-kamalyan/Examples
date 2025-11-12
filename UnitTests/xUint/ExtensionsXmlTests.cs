using Core.Entitys;
using DesignPatterns.Repository.Implementation;

namespace DesignPatterns.Implementation.xUnitTests
{
    public class ExtensionsXmlTests
    {
        private readonly StoreType _StoreType = StoreType.OnXml;

        [Fact]
        public void LoadTest()
        {
            var Data = Extensions.Load<Student>(_StoreType).ToDictionary(p => p.ID);
            if (!Data.Any())
            {
                Xunit.Assert.Fail();
            }
        }

        [Fact]
        public void WriteTest()
        {
            List<Student> st = Core.Generator.Generate<Student>(10).Select(e => e).ToList();
            Extensions.Write(st, _StoreType);
        }
    }
}