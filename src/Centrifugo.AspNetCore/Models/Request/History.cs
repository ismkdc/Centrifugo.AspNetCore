using Centrifugo.AspNetCore.Models.Abstraction;

namespace Centrifugo.AspNetCore.Models.Request
{
    public class History : IRequest
    {
        /// <summary>
        ///     Name of channel to call history from
        /// </summary>
        public string Channel { get; set; }
    }
}