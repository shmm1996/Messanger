using System;
using System.Net.Http;
using Newtonsoft.Json;
using ClientChat.ResponseObjects;

namespace ClientChat.HttpRequestHandler
{
    public class RegistrationRequestHandler : BaseRequestHandler
    {
        public RegistrationRequestHandler(string url) : base(url) { }

        public event Action<string> OnSuccesRegistrate;
        public event Action<string> OnErrorRegistrate;

        public async void RegistrateAsync(string userName, string email, string password)
        {
            using (HttpClient httpClient = new HttpClient { BaseAddress = Uri })
            {
                using (StringContent content = new StringContent(JsonConvert.SerializeObject(new { userName = userName, email = email, password = password }), System.Text.Encoding.UTF8, "application/json"))
                {
                    using (var response = await httpClient.PostAsync("reg", content))
                    {
                        string responseJson = await response.Content.ReadAsStringAsync();

                        ResponseObject<TokenResponseData> responseObject = ResponseObject.Deserialize<TokenResponseData>(responseJson);

                        if (responseObject.Success)
                            OnSuccesRegistrate?.Invoke(responseObject.data.token);
                        else
                            OnErrorRegistrate?.Invoke(responseObject.data.message);
                    }
                }
            }
        }
    }
}
