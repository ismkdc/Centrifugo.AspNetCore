using Centrifugo.AspNetCore.Models.Abstraction;

namespace Centrifugo.AspNetCore.Models.Request
{
    public class Refresh : IRequest
    {
        /// <summary>
        ///     User ID to refresh
        /// </summary>
        public string User { get; set; }
    }
}