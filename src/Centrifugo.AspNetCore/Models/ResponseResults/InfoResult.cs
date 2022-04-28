using System.Collections.Generic;
using System.Text.Json.Serialization;
using Centrifugo.AspNetCore.Models.Abstraction;

namespace Centrifugo.AspNetCore.Models.Response
{
    public class InfoResult : IResponseResult
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
        [JsonPropertyName("Num_Channels")]
        public int NumChannels { get; set; }

        /// <summary>
        /// Client count
        /// </summary>
        [JsonPropertyName("Num_Clients")]
        public int NumClients { get; set; }

        /// <summary>
        /// User count
        /// </summary>
        [JsonPropertyName("Num_Users")]
        public int NumUsers { get; set; }

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