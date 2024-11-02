using Core.Entitys;

namespace RepositoryPattern.Implementation.xUnitTests
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
                Assert.Fail();
            }
        }

        [Fact]
        public void WriteTest()
        {
            List<Student> st = Core.Generator.Generate<Student>(10).Select(e => (Student)e).ToList();
            Extensions.Write(st, _StoreType);
        }

        [Theory]
        [InlineData("1", "1")]
        [InlineData("2", "2")]
        public void Test(string key, string valeu)
        {

        }
    }
}