using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTestBotFramework
{
    public class TestEntriesCollection
    {
        [JsonProperty("secret")]
        public string Secret { get; set; }
        [JsonProperty("directlineGenerateTokenEndpoint")]
        public string DirectLineGenerateTokenEndpoint { get; set; }
        [JsonProperty("directlineConversationEndpoint")]
        public string DirectLineConversationEndpoint { get; set; }
        [JsonProperty("entries")]
        public List<TestEntry> Entries { get; set; }
    }

}
