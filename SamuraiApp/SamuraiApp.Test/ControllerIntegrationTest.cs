using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SamuraiApp.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SamuraiApp.Test
{
    [TestClass]
    public class ControllerIntegrationTest
    {
        private readonly WebApplicationFactory<SamuraiAPI.Startup> _factory;

        public ControllerIntegrationTest()
        {
            _factory = new WebApplicationFactory<SamuraiAPI.Startup>();
        }

        [TestMethod]
        public async Task GetEndpointReturnsSucessAndSomeDataFromTheDataBase()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var reponse = await client.GetAsync("/api/SamuraisSoc");
            reponse.EnsureSuccessStatusCode(); // Status code 200-299
            var reponseString = await reponse.Content.ReadAsStringAsync();
            var responseObjectList = JsonConvert.DeserializeObject<List<Samurai>>(reponseString);

            //Assert
            Assert.AreNotEqual(0, responseObjectList.Count);

        }
    }
}
