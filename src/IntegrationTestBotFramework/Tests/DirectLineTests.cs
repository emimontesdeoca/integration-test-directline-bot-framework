using System;
using System.Threading.Tasks;
using IntegrationTestBotFramework.Collections;
using IntegrationTestBotFramework.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace IntegrationTestBotFramework.Tests
{
    [TestClass]
    public class DirectLineTests
    {
        [TestMethod]
        public async Task ShouldGetTokenFromDirectLineSingleCases()
        {
            // Load entries from file
            var path = System.IO.File.ReadAllText(Data.singleCasesJson);

            // Deserialize to object
            var data = JsonConvert.DeserializeObject<TestEntriesCollection>(path);

            // Get token using secret from DirectLine in BotFramework panel
            var token = API.uploadString<DirectLineAuth>(data.Secret, data.DirectLineGenerateTokenEndpoint, "").token;

            // Assert
            Assert.IsNotNull(token);

            await Task.CompletedTask;
        }

        [TestMethod]
        public async Task ShouldGetTokenFromDirectLineFlowCases()
        {
            // Load entries from file
            var path = System.IO.File.ReadAllText(Data.flowCasesJson);

            // Deserialize to object
            var data = JsonConvert.DeserializeObject<TestEntriesCollection>(path);

            // Get token using secret from DirectLine in BotFramework panel
            var token = API.uploadString<DirectLineAuth>(data.Secret, data.DirectLineGenerateTokenEndpoint, "").token;

            // Assert
            Assert.IsNotNull(token);

            await Task.CompletedTask;
        }
    }





}
