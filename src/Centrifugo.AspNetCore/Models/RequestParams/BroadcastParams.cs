using System.Collections.Generic;
using Centrifugo.AspNetCore.Attributes;
using Centrifugo.AspNetCore.Models.Abstraction;

namespace Centrifugo.AspNetCore.Models.Request
{
    [CentrifugoName("Broadcast")]
    public class BroadcastParams : IRequestParams
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