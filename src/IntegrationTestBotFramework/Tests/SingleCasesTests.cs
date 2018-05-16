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
    public class SingleCasesTests
    {
        [TestMethod]
        public async Task ShouldTestSingleCases()
        {
            // Load entries from file
            var path = System.IO.File.ReadAllText(Data.singleCasesJson);

            // Deserialize to object
            var data = JsonConvert.DeserializeObject<TestEntriesCollection>(path);

            /// Flow: Arrange -> Act -> arrange -> assert
            foreach (TestEntry entry in data.Entries)
            {
                /// Test only enabled entry
                if (!entry.Mute)
                {
                    /// Arrange with current requested values
                    string token, newToken, conversationId;

                    if (entry.Request.Type == ActivityTypes.Message)
                    {
                        /// Act

                        /// 1 - Get token using secret from DirectLine in BotFramework panel
                        token = API.uploadString<DirectLineAuth>(data.Secret, data.DirectLineGenerateTokenEndpoint, "").token;

                        /// 2 -Create a new conversation
                        var createdConversation = API.uploadString<DirectLineAuth>(token, data.DirectLineConversationEndpoint, "");

                        // This returns a new token and a conversationId
                        newToken = createdConversation.token;
                        conversationId = createdConversation.conversationId;

                        /// 3 - Send an activity to the conversation with new token and conversationId
                        string directlineConversationActivitiesEndpoint = data.DirectLineConversationEndpoint + conversationId + "/activities";
                        API.uploadString<DirectLineAuth>(newToken, directlineConversationActivitiesEndpoint, JsonConvert.SerializeObject(entry.Request));

                        /// 4 - Get all activities, we get a List<activity> and a watermark
                        var getLastActivity = API.downloadString<ActivityResponse>(newToken, directlineConversationActivitiesEndpoint);

                        /// 5 - Get the latest activity which is the response we should be expecting
                        var latestResponse = getLastActivity.activities[Int32.Parse(getLastActivity.watermark)];

                        /// Arrange with new values
                        var globals = new Utils.Globals { Request = entry.Response, Response = latestResponse };

                        /// Assert

                        bool res = await CSharpScript.EvaluateAsync<bool>(entry.Assert, globals: globals);

                        /// DEBUG MODE
                        if (res)
                        {
                            var a = "";
                        }
                        else
                        {
                            var a = "";
                        }

                        Assert.IsTrue(res);
                        //Assert.IsTrue(await CSharpScript.EvaluateAsync<bool>(entry.Assert, globals: globals));
                    }
                }
            }
            await Task.CompletedTask;
        }
    }
}
