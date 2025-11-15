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

namespace UnitTests.xUint
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

        ISmartPhone Load(StringContent content,string Uri)
        {
            Mock<HttpMessageHandler> _Httphandler = new();
            _Httphandler
                .SetupRequest(message => message.RequestUri.AbsoluteUri == Uri)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = content,
                });

            return Configure(_Httphandler).GetRequiredService<ISmartPhone>();
        }

        [Theory]
        [JsonFileData("ListOFAllObjects.json")]
        public async Task ListOFAllObjects(StringContent content)
        {
            var phone = Load(content, "https://api.restful-api.dev/objects");
            var data = await phone.ListOFAllObjects();
            if (data.Count == 0)
                Xunit.Assert.Fail();
        }

        [Theory]
        [JsonFileData("ListOfObjectsByIds.json")]
        public async Task ListOfObjectsByIds(StringContent content)
        {
            var phone = Load(content, "https://api.restful-api.dev/objects?id=1&id=2&id=3");
            var data = await phone.ListOfObjectsByIds(["1", "2", "3"]);
            if (data.Count == 0)
                Xunit.Assert.Fail();

            //var data = await phone.SingleObject(Id);
            //await phone.AddObject(phone);
            //await phone.UpdateObject(phone);
            //await phone.DeleteObject(Id);

        }

    }
}