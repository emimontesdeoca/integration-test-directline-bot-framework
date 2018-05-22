using Microsoft.Bot.Connector;
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
        public List<Activity> activities { get; set; }
        /// <summary>
        /// Total activities
        /// </summary>
        public string watermark { get; set; }
    }
}
