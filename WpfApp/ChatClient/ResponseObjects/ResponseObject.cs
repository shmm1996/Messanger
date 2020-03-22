using System;
using Newtonsoft.Json;

namespace ClientChat.ResponseObjects
{

    [Serializable]
    public class ResponseObject<T>
    {
        private ResponseObject() { }
        public string status { get; set; }
        public bool Success => status != null && status.ToLower() == "ok";
        public T data { get; set; }
    }

    public static class ResponseObject
    {
        public static ResponseObject<T> Deserialize<T>(string json) => JsonConvert.DeserializeObject<ResponseObject<T>>(json);

        public static string Serialize(object obj) => JsonConvert.SerializeObject(obj);
    }
}
