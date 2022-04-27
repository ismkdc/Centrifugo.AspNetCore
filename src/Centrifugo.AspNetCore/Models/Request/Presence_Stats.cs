using Centrifugo.AspNetCore.Models.Abstraction;

namespace Centrifugo.AspNetCore.Models.Request
{
    public class Presence_Stats : IRequest
    {
        /// <summary>
        ///     Name of channel to call presence from
        /// </summary>
        public string Channel { get; set; }
    }
}