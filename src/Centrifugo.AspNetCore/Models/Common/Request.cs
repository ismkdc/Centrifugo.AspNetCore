using System;
using System.Reflection;
using Centrifugo.AspNetCore.Attributes;
using Centrifugo.AspNetCore.Models.Abstraction;

namespace Centrifugo.AspNetCore.Models.Common
{
    internal class Request<T> where T : IRequestParams, new()
    {
        public Request()
        {
            Params = new T();
        }

        public Request(T parameters)
        {
            Params = parameters ?? throw new ArgumentNullException(nameof(parameters));
        }

        public string Method => typeof(T).GetCustomAttribute<CentrifugoNameAttribute>()?.Name;

        public T Params { get; set; }
    }
}