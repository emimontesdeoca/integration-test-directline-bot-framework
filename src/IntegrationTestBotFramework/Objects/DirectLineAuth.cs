using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTestBotFramework
{
    /// <summary>
    /// Authorization object for DirectLine
    /// </summary>
    public class DirectLineAuth
    {
        /// <summary>
        /// Conversation Id
        /// </summary>
        public string conversationId { get; set; }
        /// <summary>
        /// New token
        /// </summary>
        public string token { get; set; }
        /// <summary>
        /// Expiration
        /// </summary>
        public int expires_in { get; set; }
    }
}
