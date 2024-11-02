using Core;
using Core.Entitys;

namespace RepositoryPattern.Implementation.MSTests
{
    [TestClass()]
    public class ExtensionsSqlTests
    {
        private readonly StoreType _StoreType = StoreType.OnEntityFramework;

        [TestMethod()]
        public void LoadTest()
        {
            var Data = Extensions.Load<Student>(_StoreType).ToDictionary(p => p.ID);
            if (!Data.Any())
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void WriteTest()
        {
            List<Student> st = Core.Generator.Generate<Student>(10).Select(e => (Student)e).ToList();
            Extensions.Write(st, _StoreType);
        }
  
    }
}