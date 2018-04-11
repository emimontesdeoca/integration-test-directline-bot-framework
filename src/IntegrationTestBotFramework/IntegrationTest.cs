using System;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

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

                    //var rightside = entry.Assert.Split(new string[] { "== " }, StringSplitOptions.None)[1];

                    var eval = "entry.Request.Text == entry.Response.Text";
                    var splitarr = eval.Split(new string[] { " == " }, StringSplitOptions.None);


                    var options = ScriptOptions.Default.AddReferences(typeof(Activity).Assembly);

                    var left = CSharpScript.EvaluateAsync(splitarr[0]);
                    var right = CSharpScript.EvaluateAsync(splitarr[1]);

                    var a = CSharpScript.EvaluateAsync<bool>(eval, options);

                    object result = await CSharpScript.EvaluateAsync("entry.Request.Text == entry.Response.Text");

                    //String propName = "Text";
                    //PropertyInfo pi = someObject.GetType().GetProperty(propName);
                    //pi.SetValue(someObject, "New Value", new Object[0]);
                }
            }

            await Task.CompletedTask;
        }


    }
}
