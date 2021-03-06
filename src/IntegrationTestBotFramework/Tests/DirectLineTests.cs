﻿using System;
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
        public async Task DirectLine_ShouldGetToken()
        {
            try
            {
                // Load entries from file
                var path = System.IO.File.ReadAllText(Data.JSON);

                // Deserialize to object
                var data = JsonConvert.DeserializeObject<TestEntriesCollection>(path);

                // Get token using secret from DirectLine in BotFramework panel
                var token = API.uploadString<DirectLineAuth>(data.Secret, data.DirectLineGenerateTokenEndpoint, "").token;

                // Assert
                Assert.IsNotNull(token);
            }
            // Exception for file not found
            catch (System.IO.FileNotFoundException)
            {
                string message = "File not found: '" + Data.JSON + "'.";
                Assert.Fail(message);
            }
            // Exception for Json deserializing
            catch (JsonSerializationException)
            {
                string message = "Error deserializing from the JSON file.";
                Assert.Fail(message);
            }
            // Overall exception
            catch (Exception)
            {
                string message = "Error getting token auth using the current DirectLine's secret.";
                Assert.Fail(message);
            }

            await Task.CompletedTask;
        }
    }
}
