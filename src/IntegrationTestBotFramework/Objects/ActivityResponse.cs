using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTestBotFramework
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
