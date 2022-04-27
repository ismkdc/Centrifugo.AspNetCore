using System.Collections.Generic;
using Centrifugo.AspNetCore.Models.Abstraction;

namespace Centrifugo.AspNetCore.Models.Response
{
    public class Channels : ChannelsInfo, IResponse
    {
    }

    public class ChannelsInfo
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
        public int Num_Clients { get; set; }
    }
}