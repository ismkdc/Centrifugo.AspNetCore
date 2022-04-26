using System.Collections.Generic;
using Centrifugo.AspNetCore.Models.Abstraction;

namespace Centrifugo.AspNetCore.Models.Response
{
    public class Channels : ChannelsInfo, IResponse
    {
    }

    public class ChannelsInfo
    {
        public Dictionary<string, ClientInfo> Channels { get; set; }
    }

    public class ClientInfo
    {
        public int Num_Clients { get; set; }
    }
}