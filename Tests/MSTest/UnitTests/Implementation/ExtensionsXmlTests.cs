using Core;
using Core.Entitys;

namespace RepositoryPattern.Implementation.MSTests
{
    [TestClass()]
    public class ExtensionsXmlTests
    {
        //   private Dictionary<int, IEntity<int>> Data;
        private readonly string _FileName = "TestData";
        private readonly StoreType _StoreType = StoreType.OnXml;

        [TestMethod()]
        public void LoadTest()
        {
            var Data = Extensions.Load<Student>(_StoreType, _FileName).ToDictionary(p => p.ID);
            if (!Data.Any())
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void WriteTest()
        {
            List<Student> st = Core.Generator.Generate<Student>(10).Select(e => (Student)e).ToList();
            Extensions.Write(st, _StoreType, _FileName);
        }
  
    }
}