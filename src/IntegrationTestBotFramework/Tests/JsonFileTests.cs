using System;
using System.Threading.Tasks;
using IntegrationTestBotFramework.Collections;
using IntegrationTestBotFramework.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace IntegrationTestBotFramework.Tests
{
    [TestClass]
    public class JsonFileTests
    {
        [TestMethod]
        public async Task ShouldGetSingleCasesFromFile()
        {
            // Load entries from file
            var path = System.IO.File.ReadAllText(Data.singleCasesJson);

            // Deserialize to object
            var data = JsonConvert.DeserializeObject<TestEntriesCollection>(path);

            // Assert
            Assert.IsNotNull(data);

            await Task.CompletedTask;
        }

        [TestMethod]
        public async Task ShouldGetFlowCasesFromFile()
        {
            // Load entries from file
            var path = System.IO.File.ReadAllText(Data.flowCasesJson);

            // Deserialize to object
            var data = JsonConvert.DeserializeObject<TestEntryFlowCollection>(path);

            // Assert
            Assert.IsNotNull(data);

            await Task.CompletedTask;
        }


    }
}
