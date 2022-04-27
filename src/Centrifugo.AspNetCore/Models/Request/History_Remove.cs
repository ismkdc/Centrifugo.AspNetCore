using Centrifugo.AspNetCore.Models.Abstraction;

namespace Centrifugo.AspNetCore.Models.Request
{
    public class History_Remove : IRequest
    {
        /// <summary>
        ///     Name of channel to remove history
        /// </summary>
        public string Channel { get; set; }
    }
}