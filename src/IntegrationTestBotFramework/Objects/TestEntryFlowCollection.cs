using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTestBotFramework.Objects
{
    public class TestEntryFlowCollection
    {
        /// <summary>
        /// DirectLine Secret
        /// </summary>
        [JsonProperty("secret")]
        public string Secret { get; set; }
        /// <summary>
        /// Endpoint to get the token using the secret for DirectLine
        /// </summary>
        [JsonProperty("directlineGenerateTokenEndpoint")]
        public string DirectLineGenerateTokenEndpoint { get; set; }
        /// <summary>
        /// Endpoint for a conversation in DirectLine
        /// </summary>
        [JsonProperty("directlineConversationEndpoint")]
        public string DirectLineConversationEndpoint { get; set; }
        /// <summary>
        /// Entries list
        /// </summary>
        [JsonProperty("entries")]
        public List<TestEntryFlow> Entries { get; set; }
    }
}
