using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTestBotFramework.Objects
{
    public class TestEntryFlow
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
        /// Activity requested by the entry
        /// </summary>
        [JsonProperty("requests")]
        public List<Activity> Requests { get; set; }
        /// <summary>
        /// Activity response expected by the entry
        /// </summary>
        [JsonProperty("response")]
        public Activity Response { get; set; }
        /// <summary>
        /// Assert value in string
        /// </summary>
        [JsonProperty("assert")]
        public string Assert { get; set; }
    }
}
