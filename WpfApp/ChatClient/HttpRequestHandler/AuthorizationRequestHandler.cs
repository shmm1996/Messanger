using System;
using System.Net.Http;
using Newtonsoft.Json;
using ClientChat.ResponseObjects;

namespace ClientChat.HttpRequestHandler
{
    public class AuthorizationRequestHandler : BaseRequestHandler
    {
        public AuthorizationRequestHandler(string url) : base(url) { }

        public event Action<string> OnSuccesAuthorize;
        public event Action<string> OnErrorAuthorize;

        public async void AuthorizeAsync(string userName, string password)
        {
            using (HttpClient httpClient = new HttpClient { BaseAddress = Uri })
            {
                using (StringContent content = new StringContent(JsonConvert.SerializeObject(new { userName = userName, password = password }), System.Text.Encoding.UTF8, "application/json"))
                {
                    using (var response = await httpClient.PostAsync("auth", content))
                    {
                        string responseJson = await response.Content.ReadAsStringAsync();

                        ResponseObject<TokenResponseData> responseObject = ResponseObject.Deserialize<TokenResponseData>(responseJson);

                        if (responseObject.Success)
                            OnSuccesAuthorize?.Invoke(responseObject.data.token);
                        else
                            OnErrorAuthorize?.Invoke(responseObject.data.message);
                    }
                }
            }
        }
    }
}
