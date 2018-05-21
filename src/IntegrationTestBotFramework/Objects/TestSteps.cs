using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTestBotFramework.Objects
{
    public class TestSteps
    {
        /// <summary>
        /// Activity request to send
        /// </summary>
        [JsonProperty("request")]
        public Activity Request { get; set; }
        /// <summary>
        /// Response request to send
        /// </summary>
        [JsonProperty("response")]
        public Activity Response { get; set; }
        /// <summary>
        /// Assert in this case
        /// </summary>
        [JsonProperty("assert")]
        public string Assert { get; set; }
    }
}
