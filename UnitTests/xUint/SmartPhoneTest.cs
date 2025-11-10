using Api;
using Api.Models;
using Api.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;
using Moq.Contrib.HttpClient;
using Moq.Protected;
using System.Net;
using Xunit;

namespace Api.Services.UnitTests
{
    public class SmartPhoneTest
    {

        private IServiceProvider Configure(Mock<HttpMessageHandler> _Httphandler)
        {
            var service = new ServiceCollection();

            service.AddHttpClient<ISmartPhone, SmartPhone>()
                .ConfigurePrimaryHttpMessageHandler(() => _Httphandler.Object);

            return service.BuildServiceProvider();
        }

        [Theory]
        [JsonFileData("ListOFAllObjects.json")]
        public async Task ListOFAllObjectsTest(StringContent content)
        {
            Mock<HttpMessageHandler> _Httphandler = new();
            _Httphandler
                .SetupRequest(message => message.RequestUri.AbsoluteUri == "https://api.restful-api.dev/objects")
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = content,
                });

            var phone = Configure(_Httphandler).GetRequiredService<ISmartPhone>();

            var data = await phone.ListOFAllObjects();
            if (!data.Any())
                Xunit.Assert.Fail();
        }

        public static IEnumerable<object[]> GetPhoneIds()
        {
            yield return new object[] { new List<string> { "1", "2", "3" } };
            yield return new object[] { new List<string> { "4", "5", "6" } };
        }

        [Theory]
        [MemberData(nameof(GetPhoneIds))]
        public async void ListOfObjectsByIdsTest(IEnumerable<string> phonesID)
        {
            //var data = await phone.ListOfObjectsByIds(phonesID);
            //if (!data.Any())
            //    Assert.Fail();
        }

        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        public async void SingleObjectTest(string Id)
        {
            //var data = await phone.SingleObject(Id);
            //if (data.Id != Id)
            //    Assert.Fail();
        }

        [Fact]
        public async void AddObjectTest()
        {
            //await phone.AddObject(phone);
        }

        [Fact]
        public async void UpdateObjectTest()
        {
            //await phone.UpdateObject(phone);
        }

        [Fact]
        public async void DeleteObjectTest()
        {
            //await phone.DeleteObject(Id);
        }


    }
}

public class SmartPhoneMock : ISmartPhone
{
    public Task<Phone?> AddObject(Phone phone)
    {
        throw new NotImplementedException();
    }

    public Task<Dictionary<string, string>?> DeleteObject(string Id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Phone>?> ListOFAllObjects()
    {
        throw new NotImplementedException();
    }

    public Task<List<Phone>?> ListOfObjectsByIds(IEnumerable<string> Ids)
    {
        throw new NotImplementedException();
    }

    public Task<Phone?> SingleObject(string Id)
    {
        throw new NotImplementedException();
    }

    public Task<Phone?> UpdateObject(Phone phone)
    {
        throw new NotImplementedException();
    }
}