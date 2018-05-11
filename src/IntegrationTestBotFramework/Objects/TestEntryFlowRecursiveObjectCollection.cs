using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTestBotFramework.Objects
{
    public class TestEntryFlowRecursiveObjectCollection
    {
        /// <summary>
        /// Activity request to send
        /// </summary>
        [JsonProperty("Request")]
        public Activity Request { get; set; }
        /// <summary>
        /// Response request to send
        /// </summary>
        [JsonProperty("Response")]
        public Activity Response { get; set; }
        /// <summary>
        /// Assert in this case
        /// </summary>
        [JsonProperty("Assert")]
        public string Assert { get; set; }
    }
}
