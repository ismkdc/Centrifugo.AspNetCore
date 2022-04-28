using Centrifugo.AspNetCore.Attributes;
using Centrifugo.AspNetCore.Models.Abstraction;

namespace Centrifugo.AspNetCore.Models.Request
{
    [CentrifugoName("Refresh")]
    public class RefreshParams : IRequestParams
    {
        /// <summary>
        ///     User ID to refresh
        /// </summary>
        public string User { get; set; }
    }
}