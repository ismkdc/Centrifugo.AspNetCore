using System;

namespace Centrifugo.AspNetCore.Attributes
{
    public class CentrifugoNameAttribute : Attribute
    {
        public string Name { get; }

        public CentrifugoNameAttribute(string name)
        {
            Name = name;
        }
    }
}