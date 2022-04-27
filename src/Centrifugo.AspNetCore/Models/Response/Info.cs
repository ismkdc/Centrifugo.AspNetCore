using System.Collections.Generic;
using Centrifugo.AspNetCore.Models.Abstraction;

namespace Centrifugo.AspNetCore.Models.Response
{
    public class Info : IResponse
    {
        /// <summary>
        /// List of nodes
        /// </summary>
        public IEnumerable<NodeInfo> Nodes { get; set; }
    }

    public class NodeInfo
    {
        /// <summary>
        /// Node name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Channel count
        /// </summary>
        public int Num_Channels { get; set; }

        /// <summary>
        /// Client count
        /// </summary>
        public int Num_Clients { get; set; }

        /// <summary>
        /// User count
        /// </summary>
        public int Num_Users { get; set; }

        /// <summary>
        /// Uid of the node
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// Up time of the node
        /// </summary>
        public int Uptime { get; set; }

        /// <summary>
        /// Version of the node
        /// </summary>
        public string Version { get; set; }
    }
}