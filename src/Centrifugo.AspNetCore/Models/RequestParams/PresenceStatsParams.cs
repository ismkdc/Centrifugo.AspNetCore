using Centrifugo.AspNetCore.Attributes;
using Centrifugo.AspNetCore.Models.Abstraction;

namespace Centrifugo.AspNetCore.Models.Request
{
    [CentrifugoName("Presence_Stats")]
    public class PresenceStatsParams : IRequestParams
    {
        /// <summary>
        ///     Name of channel to call presence from
        /// </summary>
        public string Channel { get; set; }
    }
}