using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

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
                string token, newToken, conversationId;

                if (entry.Request.Type == ActivityTypes.Message)
                {
                    /// CONSEGUIR TOKEN PASANDO EL SECRET
                    token = Utils.uploadString<DirectLineAuth>(data.Secret, data.DirectLineGenerateTokenEndpoint, "").token;

                    /// CREAR CONVERSACION
                    var createdConversation = Utils.uploadString<DirectLineAuth>(token, data.DirectLineConversationEndpoint, "");
                    newToken = createdConversation.token;
                    conversationId = createdConversation.conversationId;

                    /// ENVIAR ACTIVIDAD
                    string directlineConversationActivitiesEndpoint = data.DirectLineConversationEndpoint + conversationId + "/activities";
                    var sendToConversation = Utils.uploadString<DirectLineAuth>(newToken, directlineConversationActivitiesEndpoint, JsonConvert.SerializeObject(entry.Request));

                    /// CONSEGUIR TODAS LAS ACTIVIDADES
                    var getLastActivity = Utils.downloadString<ActivityResponse>(newToken, directlineConversationActivitiesEndpoint);

                    /// CONSEGUIR LA ULTIMA (RESPUESTA)
                    var latestResponse = getLastActivity.activities[Int32.Parse(getLastActivity.watermark)];

                }
            }

            await Task.CompletedTask;
        }


    }
}
