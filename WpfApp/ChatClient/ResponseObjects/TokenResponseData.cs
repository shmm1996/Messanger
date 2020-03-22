using System;

namespace ClientChat.ResponseObjects
{

    [Serializable]
    public class TokenResponseData
    {
        private TokenResponseData() { }
        public string token { get; set; }
        public string message { get; set; }
    }
}
