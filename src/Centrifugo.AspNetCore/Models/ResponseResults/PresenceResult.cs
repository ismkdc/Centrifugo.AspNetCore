using System.Collections.Generic;
using Centrifugo.AspNetCore.Models.Abstraction;

namespace Centrifugo.AspNetCore.Models.Response
{
    public class PresenceResult : PresenceInfo, IResponseResult
    {
    }

    public class PresenceInfo : IResponseResult
    {
        /// <summary>
        /// Offset of publication in history stream
        /// </summary>
        public Dictionary<string, PresenceClientInfo> Presence { get; set; }
    }

    public class PresenceClientInfo : IResponseResult
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