using Core.Entitys;
using DesignPatterns.Repository.StorageՕptions;

namespace UnitTests.xUint
{
    public class XmlStorage
    {

        [Fact]
        public void LoadTest()
        {
            var Data = new OnXml().Load<Student>();
            if (!Data.Any())
            {
                Xunit.Assert.Fail();
            }
        }

        [Fact]
        public void WriteTest()
        {
            List<Student> st = Core.Generator.Generate<Student>(10).Select(e => e).ToList();
            new OnXml().Write(st);
        }
    }
}