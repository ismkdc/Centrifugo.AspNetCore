using System.Collections.Generic;
using Centrifugo.AspNetCore.Models.Abstraction;

namespace Centrifugo.AspNetCore.Models.Response
{
    public class Info : IResponse
    {
        public IEnumerable<NodeInfo> Nodes { get; set; }
    }

    public class NodeInfo
    {
        public string Name { get; set; }
        public int Num_Channels { get; set; }
        public int Num_Clients { get; set; }
        public int Num_Users { get; set; }
        public string Uid { get; set; }
        public int Uptime { get; set; }
        public string Version { get; set; }
    }
}