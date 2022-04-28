using System.Text.Json.Serialization;
using Centrifugo.AspNetCore.Models.Abstraction;

namespace Centrifugo.AspNetCore.Models.Response
{
    public class PresenceStatsResult : IResponseResult
    {
        /// <summary>
        /// Total number of clients in channel
        /// </summary>
        [JsonPropertyName("Num_Clients")]
        public int NumClients { get; set; }

        /// <summary>
        /// Total number of unique users in channel
        /// </summary>
        [JsonPropertyName("Num_Users")]
        public int NumUsers { get; set; }
    }
}