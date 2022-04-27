using Centrifugo.AspNetCore.Models.Abstraction;

namespace Centrifugo.AspNetCore.Models.Request
{
    public class Subscribe : IRequest
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