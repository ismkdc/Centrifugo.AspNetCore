using Centrifugo.AspNetCore.Attributes;
using Centrifugo.AspNetCore.Models.Abstraction;

namespace Centrifugo.AspNetCore.Models.Request
{
    [CentrifugoName("History_Remove")]
    public class HistoryRemoveParams : IRequestParams
    {
        /// <summary>
        ///     Name of channel to remove history
        /// </summary>
        public string Channel { get; set; }
    }
}