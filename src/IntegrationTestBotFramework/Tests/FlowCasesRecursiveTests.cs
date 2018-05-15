﻿using System;
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
    public class FlowCasesRecursiveTests
    {
        //[TestMethod]
        public async Task ShouldTestFlowRecursiveCases()
        {
            // Load entries from file
            var path = System.IO.File.ReadAllText(Data.flowCasesJson);

            // Deserialize to object
            var data = JsonConvert.DeserializeObject<TestEntryFlowRecursiveCollection>(path);

            /// Flow: Arrange -> Act -> arrange -> assert
            foreach (TestEntryFlowRecursive entry in data.Entries)
            {
                /// Arrange with current requested values
                string token, newToken, conversationId;
                Activity latestResponse = new Activity();

                /// Just do Enabled cases
                if (entry.Mute)
                {
                    /// Act for step

                    /// 1 - Get token using secret from DirectLine in BotFramework panel
                    token = API.uploadString<DirectLineAuth>(data.Secret, data.DirectLineGenerateTokenEndpoint, "").token;

                    /// 2 -Create a new conversation
                    var createdConversation = API.uploadString<DirectLineAuth>(token, data.DirectLineConversationEndpoint, "");

                    // This returns a new token and a conversationId
                    newToken = createdConversation.token;
                    conversationId = createdConversation.conversationId;

                    /// 3 - Send an activity to the conversation with new token and conversationId
                    string directlineConversationActivitiesEndpoint = data.DirectLineConversationEndpoint + conversationId + "/activities";

                    foreach (TestEntryFlowRecursiveObjectCollection step in entry.Entries)
                    {
                        if (step.Request.Type == ActivityTypes.Message)
                        {

                            /// Step
                            API.uploadString<DirectLineAuth>(newToken, directlineConversationActivitiesEndpoint, JsonConvert.SerializeObject(step));

                            /// Only assert if asset is not null
                            if (!String.IsNullOrEmpty(step.Assert))
                            {
                                /// 4 - Get all activities, we get a List<activity> and a watermark
                                var getLastActivity = API.downloadString<ActivityResponse>(newToken, directlineConversationActivitiesEndpoint);

                                /// 5 - Get the latest activity which is the response we should be expecting
                                latestResponse = getLastActivity.activities[Int32.Parse(getLastActivity.watermark)];

                                /// Arrange with new values
                                var globals = new Utils.Globals { Request = step.Response, Response = latestResponse };


                                bool res = await CSharpScript.EvaluateAsync<bool>(step.Assert, globals: globals);


                                // debug mode
                                if (res)
                                {
                                    var a = "";
                                }
                                else
                                {
                                    var a = "";
                                }

                                Assert.IsTrue(res);

                                /// Assert
                                //Assert.IsTrue(await CSharpScript.EvaluateAsync<bool>(step.Assert, globals: globals));

                            }
                        }
                    }
                }




            }

            await Task.CompletedTask;
        }
    }
}