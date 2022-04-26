using System;
using Centrifugo.AspNetCore.Models.Abstraction;

namespace Centrifugo.AspNetCore.Models.Common
{
    public class Request<T> where T : IRequest, new()
    {
        public Request()
        {
            Params = new T();
        }

        public Request(T parameters)
        {
            Params = parameters ?? throw new ArgumentNullException(nameof(parameters));
        }

        public string Method => typeof(T).Name;
        public T Params { get; set; }
    }
}