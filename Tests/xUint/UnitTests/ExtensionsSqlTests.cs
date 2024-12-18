using Core.Entitys;
using DesignPatterns.Repository.Implementation;

namespace DesignPatterns.Implementation.xUnitTests
{
    public class ExtensionsSqlTests
    {
        private readonly StoreType _StoreType = StoreType.OnEntityFramework;

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
    }
}