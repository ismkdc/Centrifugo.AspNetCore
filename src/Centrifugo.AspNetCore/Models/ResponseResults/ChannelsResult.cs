using System.Collections.Generic;
using System.Text.Json.Serialization;
using Centrifugo.AspNetCore.Models.Abstraction;

namespace Centrifugo.AspNetCore.Models.Response
{
    public class ChannelsResult : IResponseResult
    {
        /// <summary>
        /// Key value pairs of channel name and channel info.
        /// </summary>
        public Dictionary<string, ChannelClientInfo> Channels { get; set; }
    }

    public class ChannelClientInfo
    {
        /// <summary>
        /// Total number of connections currently subscribed to a channel
        /// </summary>
        [JsonPropertyName("Num_Clients")]
        public int NumClients { get; set; }
    }
}