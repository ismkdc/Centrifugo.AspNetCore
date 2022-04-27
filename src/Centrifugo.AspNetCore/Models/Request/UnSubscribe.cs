using Centrifugo.AspNetCore.Models.Abstraction;

namespace Centrifugo.AspNetCore.Models.Request
{
    public class UnSubscribe : IRequest
    {
        /// <summary>
        ///     User ID to unsubscribe
        /// </summary>
        public string User { get; set; }

        /// <summary>
        ///     Name of channel to unsubscribe user to
        /// </summary>
        public string Channel { get; set; }
    }
}