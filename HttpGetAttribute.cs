using System;

namespace WebApplication2_Y2
{
    internal class HttpGetAttribute : Attribute
    {
        private string v;

        public HttpGetAttribute(string v)
        {
            this.v = v;
        }
    }
}