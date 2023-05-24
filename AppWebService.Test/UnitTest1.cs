using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace AppWebService.Test
{
    public class Tests //: IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        /*public Tests(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }*/

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}