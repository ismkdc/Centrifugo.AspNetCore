using System.Collections.Generic;
using Centrifugo.AspNetCore.Models.Abstraction;

namespace Centrifugo.AspNetCore.Models.Response
{
    public class HistoryResult : IResponseResult
    {
        /// <summary>
        /// Stream epoch
        /// </summary>
        public string Epoch { get; set; }

        /// <summary>
        /// Offset in a stream
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// List of messages
        /// </summary>
        public IEnumerable<HistoryPublication> Publications { get; set; }
    }

    public class HistoryPublication
    {
        /// <summary>
        /// Offset in a stream
        /// </summary>
        public int Offset { get; set; }


        /// <summary>
        /// Message data
        /// </summary>
        public Dictionary<string, string> Data { get; set; }
    }
}