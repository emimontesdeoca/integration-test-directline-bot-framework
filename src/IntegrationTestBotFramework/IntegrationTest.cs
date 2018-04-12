using System;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Microsoft.CodeAnalysis.CSharp.Scripting;

namespace IntegrationTestBotFramework
{
    [TestClass]
    public class IntegrationTest
    {
        [TestMethod]
        public async Task TestFromFile()
        {
            // Load entries from file
            var path = System.IO.File.ReadAllText(@"C:\data.json");

            // Deserialize to object
            var data = JsonConvert.DeserializeObject<TestEntriesCollection>(path);

            foreach (var entry in data.Entries)
            {
                /// Arrange with current requested values
                string token, newToken, conversationId;

                if (entry.Request.Type == ActivityTypes.Message)
                {
                    /// Act

                    /// 1 - Get token using secret from DirectLine in BotFramework panel
                    token = Utils.uploadString<DirectLineAuth>(data.Secret, data.DirectLineGenerateTokenEndpoint, "").token;

                    /// 2 -Create a new conversation
                    var createdConversation = Utils.uploadString<DirectLineAuth>(token, data.DirectLineConversationEndpoint, "");

                    // This returns a new token and a conversationId
                    newToken = createdConversation.token;
                    conversationId = createdConversation.conversationId;

                    /// 3 - Send an activity to the conversation with new token and conversationId
                    string directlineConversationActivitiesEndpoint = data.DirectLineConversationEndpoint + conversationId + "/activities";
                    Utils.uploadString<DirectLineAuth>(newToken, directlineConversationActivitiesEndpoint, JsonConvert.SerializeObject(entry.Request));

                    /// 4 - Get all activities, we get a List<activity> and a watermark
                    var getLastActivity = Utils.downloadString<ActivityResponse>(newToken, directlineConversationActivitiesEndpoint);

                    /// 5 - Get the latest activity which is the response we should be expecting
                    var latestResponse = getLastActivity.activities[Int32.Parse(getLastActivity.watermark)];

                    /// Arrange with new values
                    var globals = new Objects.Globals { Request = entry.Response, Response = latestResponse };

                    /// Assert
                    Assert.IsTrue(await CSharpScript.EvaluateAsync<bool>(entry.Assert, globals: globals));
                }
            }
            await Task.CompletedTask;
        }
    }
}
