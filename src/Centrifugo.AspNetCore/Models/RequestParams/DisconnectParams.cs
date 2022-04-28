using Centrifugo.AspNetCore.Attributes;
using Centrifugo.AspNetCore.Models.Abstraction;

namespace Centrifugo.AspNetCore.Models.Request
{
    [CentrifugoName("Disconnect")]
    public class DisconnectParams : IRequestParams
    {
        /// <summary>
        ///     User ID to disconnect
        /// </summary>
        public string User { get; set; }
    }
}