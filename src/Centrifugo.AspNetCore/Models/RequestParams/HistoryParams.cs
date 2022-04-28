using Centrifugo.AspNetCore.Attributes;
using Centrifugo.AspNetCore.Models.Abstraction;

namespace Centrifugo.AspNetCore.Models.Request
{
    [CentrifugoName("History")]
    public class HistoryParams : IRequestParams
    {
        /// <summary>
        ///     Name of channel to call history from
        /// </summary>
        public string Channel { get; set; }
    }
}