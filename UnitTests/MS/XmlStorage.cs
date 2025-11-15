using Core;
using Core.Entitys;
using DesignPatterns.Repository.StorageՕptions;

namespace UnitTests.MS
{
    [TestClass()]
    public class XmlStorage
    {
        [TestMethod()]
        public void LoadTest()
        {
            var Data = new OnXml().Load<Student>();
            if (!Data.Any())
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail();
            }
        }

        [TestMethod()]
        public void WriteTest()
        {
            List<Student> st = Generator.Generate<Student>(10).Select(e => e).ToList();
            new OnXml().Write(st);
        }
  
    }
}