﻿using Microsoft.Bot.Connector;

namespace IntegrationTestBotFramework.Objects
{
    /// <summary>
    /// Object to pass parameters to Roslyn compiler
    /// </summary>
    public class Globals
    {
        /// <summary>
        /// ExpectedResponse
        /// </summary>
        public Activity Request;
        /// <summary>
        /// ReceivedResponse
        /// </summary>
        public Activity Response;
    }
}
