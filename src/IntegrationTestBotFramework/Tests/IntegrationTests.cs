using System;
using System.Threading.Tasks;
using IntegrationTestBotFramework.Collections;
using IntegrationTestBotFramework.Objects;
using IntegrationTestBotFramework.Utils;
using Microsoft.Bot.Connector;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace IntegrationTestBotFramework.Tests
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public async Task Tests_ShouldTestAllCases()
        {
            // String for exception
            string casename = "", stepn = "";

            try
            {
                // Load entries from file
                var path = System.IO.File.ReadAllText(Data.JSON);

                // Deserialize to object
                var data = JsonConvert.DeserializeObject<TestEntriesCollection>(path);

                // Flow: Arrange -> Act -> arrange -> assert
                foreach (TestEntry entry in data.Entries)
                {

                    // Arrange with current requested values
                    string token, newToken, conversationId;
                    Activity latestResponse = new Activity();

                    // Set vars for exception
                    casename = entry.Name;

                    // Just do Enabled cases
                    if (!entry.Mute)
                    {
                        // Act for step

                        // 1 - Get token using secret from DirectLine in BotFramework panel
                        token = API.uploadString<DirectLineAuth>(data.Secret, data.DirectLineGenerateTokenEndpoint, "").token;

                        // 2 -Create a new conversation
                        var createdConversation = API.uploadString<DirectLineAuth>(token, data.DirectLineConversationEndpoint, "");

                        // This returns a new token and a conversationId
                        newToken = createdConversation.token;
                        conversationId = createdConversation.conversationId;

                        // 3 - Send an activity to the conversation with new token and conversationId
                        string directlineConversationActivitiesEndpoint = data.DirectLineConversationEndpoint + conversationId + "/activities";

                        /// Iterator for index
                        var i = 0;
                        foreach (TestSteps step in entry.Steps)
                        {
                            // Set var for exception data
                            stepn = i.ToString();

                            if (step.Request.Type == ActivityTypes.Message)
                            {
                                /// Step
                                API.uploadString<DirectLineAuth>(newToken, directlineConversationActivitiesEndpoint, JsonConvert.SerializeObject(step.Request));

                                /// Only assert if asset is not null        
                                if (!String.IsNullOrEmpty(step.Assert))
                                {
                                    /// 4 - Get all activities, we get a List<activity> and a watermark
                                    var getLastActivity = API.downloadString<ActivityResponse>(newToken, directlineConversationActivitiesEndpoint);

                                    /// 5 - Get the latest activity which is the response we should be expecting
                                    latestResponse = getLastActivity.activities[Int32.Parse(getLastActivity.watermark)];

                                    /// 6 - Set the globals with the data
                                    var globals = new Utils.Globals { Request = step.Response, Response = latestResponse };

                                    /// 7 - Evaluate
                                    Assert.IsTrue(await CSharpScript.EvaluateAsync<bool>(step.Assert, globals: globals));

                                }
                            }
                            i++;
                        }
                    }
                }
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
                string message = "\r\nCase name: " + casename + "\r\nStep: " + stepn;
                Assert.Fail(message);
            }


            await Task.CompletedTask;
        }
    }
}
