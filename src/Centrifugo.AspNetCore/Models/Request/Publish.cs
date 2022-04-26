using Centrifugo.AspNetCore.Models.Abstraction;

namespace Centrifugo.AspNetCore.Models.Request
{
    public class Publish : IRequest
    {
        public string Channel { get; set; }
        public object Data { get; set; }
    }
}