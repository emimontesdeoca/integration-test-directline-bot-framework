using IntegrationTestBotFramework.Objects;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace IntegrationTestBotFramework.Collections
{
    /// <summary>
    /// Object to parse from the file
    /// </summary>
    public class TestEntriesCollection
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
        public List<TestEntry> Entries { get; set; }
    }

}
