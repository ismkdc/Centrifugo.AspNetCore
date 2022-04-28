using Centrifugo.AspNetCore.Attributes;
using Centrifugo.AspNetCore.Models.Abstraction;

namespace Centrifugo.AspNetCore.Models.Request
{
    [CentrifugoName("Presence")]
    public class PresenceParams : IRequestParams
    {
        /// <summary>
        ///     Name of channel to call presence from
        /// </summary>
        public string ChannelParams { get; set; }
    }
}