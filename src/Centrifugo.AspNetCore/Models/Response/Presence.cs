using System.Collections.Generic;
using Centrifugo.AspNetCore.Models.Abstraction;

namespace Centrifugo.AspNetCore.Models.Response
{
    public class Presence : PresenceInfo, IResponse
    {
    }

    public class PresenceInfo : IResponse
    {
        /// <summary>
        /// Offset of publication in history stream
        /// </summary>
        public Dictionary<string, PresenceClientInfo> Presence { get; set; }
    }

    public class PresenceClientInfo : IResponse
    {
        /// <summary>
        /// Client ID
        /// </summary>
        public string Client { get; set; }

        /// <summary>
        /// User ID
        /// </summary>
        public string User { get; set; }
    }
}