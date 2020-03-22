using System;

namespace ClientChat.HttpRequestHandler
{
    public abstract class BaseRequestHandler
    {
        protected string Url { get; private set; }
        protected string Token { get; private set; }
        protected Uri Uri { get; private set; }

        public BaseRequestHandler(string url)
        {
            Url = url;
            Uri = new Uri(url);
        }

        public BaseRequestHandler(string url, string token) : this(url) => Token = token;
    }
}
