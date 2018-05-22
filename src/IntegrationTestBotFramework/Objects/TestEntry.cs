using Newtonsoft.Json;
using System.Collections.Generic;

namespace IntegrationTestBotFramework.Objects
{
    public class TestEntry
    {
        /// <summary>
        /// Entry name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// Entry description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        /// <summary>
        /// Entry status
        /// </summary>
        [JsonProperty("mute")]
        public bool Mute { get; set; }

        /// <summary>
        /// Entries for this type of testing
        /// </summary>
        [JsonProperty("steps")]
        public List<TestSteps> Steps { get; set; }
    }
}
