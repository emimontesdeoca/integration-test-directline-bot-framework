using System;
using System.IO;
using System.Threading.Tasks;
using IntegrationTestBotFramework.Collections;
using IntegrationTestBotFramework.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace IntegrationTestBotFramework.Tests
{
    [TestClass]
    public class FileTests
    {
        [TestMethod]
        public async Task File_ShouldGetTests()
        {
            try
            {
                // Load entries from file
                var path = System.IO.File.ReadAllText(Data.JSON);

                // Deserialize to object
                var data = JsonConvert.DeserializeObject<TestEntriesCollection>(path);

                // Assert
                Assert.IsNotNull(data);
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
            // Common exception
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            await Task.CompletedTask;
        }

        [TestMethod]
        public async Task File_Exists()
        {
            // Load entries from file
            if (!File.Exists(Data.JSON))
            {
                // Message if doesn't exists
                string message = "File not found: '" + Data.JSON + "'.";
                Assert.Fail(message);
            }

            await Task.CompletedTask;
        }

    }
}
