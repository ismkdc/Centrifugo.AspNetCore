using System.Collections.Generic;
using Centrifugo.AspNetCore.Models.Abstraction;

namespace Centrifugo.AspNetCore.Models.Request
{
    public class Broadcast : IRequest
    {
        public IEnumerable<string> Channels { get; set; }
        public object Data { get; set; }
    }
}