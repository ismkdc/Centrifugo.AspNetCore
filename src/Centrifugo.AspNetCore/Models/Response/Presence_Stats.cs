using Centrifugo.AspNetCore.Models.Abstraction;

namespace Centrifugo.AspNetCore.Models.Response
{
    public class Presence_Stats : IResponse
    {
        /// <summary>
        /// Total number of clients in channel
        /// </summary>
        public int Num_Clients { get; set; }

        /// <summary>
        /// Total number of unique users in channel
        /// </summary>
        public int Num_Users { get; set; }
    }
}