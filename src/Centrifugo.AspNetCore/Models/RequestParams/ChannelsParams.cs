using Centrifugo.AspNetCore.Attributes;
using Centrifugo.AspNetCore.Models.Abstraction;

namespace Centrifugo.AspNetCore.Models.Request
{
    [CentrifugoName("Channels")]
    internal class ChannelsParams : IRequestParams
    {
    }
}