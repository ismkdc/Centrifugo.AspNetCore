using Centrifugo.AspNetCore.Models.Abstraction;

namespace Centrifugo.AspNetCore.Models.Request
{
    public class Disconnect : IRequest
    {
        /// <summary>
        ///     User ID to disconnect
        /// </summary>
        public string User { get; set; }
    }
}