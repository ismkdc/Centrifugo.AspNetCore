using Centrifugo.AspNetCore.Models.Abstraction;

namespace Centrifugo.AspNetCore.Models.Request
{
    public class Publish : IRequest
    {
        /// <summary>
        ///     Name of channel to publish
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        ///     Custom JSON data to publish into a channel
        /// </summary>
        public object Data { get; set; }
    }
}