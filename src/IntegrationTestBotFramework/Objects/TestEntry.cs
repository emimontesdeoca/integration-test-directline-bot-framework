using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTestBotFramework
{
    public class TestEntry
    {
        /// <summary>
        /// Entry name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// Activity requested by the entry
        /// </summary>
        [JsonProperty("request")]
        public Activity Request { get; set; }
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
