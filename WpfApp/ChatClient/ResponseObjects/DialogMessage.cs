using System;

namespace ClientChat.ResponseObjects
{

    [Serializable]
    public class DialogMessage
    {
        private DialogMessage() { }
        public string sender { get; set; }
        public string receiver { get; set; }
        public string content { get; set; }
        public UInt64 date { get; set; }
    }
}
