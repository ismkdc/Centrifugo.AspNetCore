﻿using Centrifugo.AspNetCore.Models.Abstraction;

namespace Centrifugo.AspNetCore.Models.Common
{
    public class Response<T> where T : IResponseResult
    {
        public T Result { get; set; }
        public Error Error { get; set; }
        public bool IsSuccess => Error == null;
    }
}