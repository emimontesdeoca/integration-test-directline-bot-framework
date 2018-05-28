using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace IntegrationTestBotFramework.Utils
{
    /// <summary>
    /// Class for response when getting all activities
    /// </summary>
    class ActivityResponse
    {
        /// <summary>
        /// Activities list
        /// </summary>
        [JsonProperty("activities")]
        public List<Activity> Activities { get; set; }
        /// <summary>
        /// Total activities
        /// </summary>
        [JsonProperty("watermark")]
        public string Watermark { get; set; }
    }
}
