using System;

namespace ClientChat.ResponseObjects
{

    [Serializable]
    public class MessageResponseData
    {
        private MessageResponseData() { }
        public string message { get; set; }
    }
}
