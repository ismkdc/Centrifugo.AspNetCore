using System.Collections.Generic;
using Centrifugo.AspNetCore.Models.Abstraction;

namespace Centrifugo.AspNetCore.Models.Request
{
    public class Broadcast : IRequest
    {
        /// <summary>
        ///     List of channels to publish data to
        /// </summary>
        public IEnumerable<string> Channels { get; set; }

        /// <summary>
        ///     Custom JSON data to publish into each channel
        /// </summary>
        public object Data { get; set; }
    }
}