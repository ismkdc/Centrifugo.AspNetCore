using Centrifugo.AspNetCore.Attributes;
using Centrifugo.AspNetCore.Models.Abstraction;

namespace Centrifugo.AspNetCore.Models.Request
{
    [CentrifugoName("Subscribe")]
    public class SubscribeParams : IRequestParams
    {
        /// <summary>
        ///     User ID to subscribe
        /// </summary>
        public string User { get; set; }

        /// <summary>
        ///     Name of channel to subscribe user to
        /// </summary>
        public string Channel { get; set; }
    }
}