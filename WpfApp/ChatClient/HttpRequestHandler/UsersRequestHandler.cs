using System;
using System.Net.Http;
using Newtonsoft.Json;
using ClientChat.ResponseObjects;

namespace ClientChat.HttpRequestHandler
{
    public class UsersRequestHandler : BaseRequestHandler
    {
        public UsersRequestHandler(string url, string token) : base(url, token) { }

        public event Action<string> OnSuccesCreateUser;
        public event Action<string> OnErrorCreateUser;

        public async void CreateUserAsync(string userName, string email, string password)
        {
            using (HttpClient httpClient = new HttpClient { BaseAddress = Uri })
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization", Token);

                using (StringContent content = new StringContent(JsonConvert.SerializeObject(new { userName = userName, email = email, password = password }), System.Text.Encoding.UTF8, "application/json"))
                {
                    using (var response = await httpClient.PostAsync("users", content))
                    {
                        string responseJson = await response.Content.ReadAsStringAsync();

                        ResponseObject<MessageResponseData> responseObject = ResponseObject.Deserialize<MessageResponseData>(responseJson);

                        if (responseObject.Success)
                            OnSuccesCreateUser?.Invoke(responseObject.data.message);
                        else
                            OnErrorCreateUser?.Invoke(responseObject.data.message);
                    }
                }
            }
        }

        public event Action<string> OnSuccesUpdateUser;
        public event Action<string> OnErrorUpdateUser;

        public async void UpdateUserAsync(string email, string password)
        {
            using (HttpClient httpClient = new HttpClient { BaseAddress = Uri })
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization", Token);

                using (StringContent content = new StringContent(JsonConvert.SerializeObject(new { email = email, password = password }), System.Text.Encoding.UTF8, "application/json"))
                {
                    using (var response = await httpClient.PutAsync("users", content))
                    {
                        string responseJson = await response.Content.ReadAsStringAsync();

                        ResponseObject<MessageResponseData> responseObject = ResponseObject.Deserialize<MessageResponseData>(responseJson);

                        if (responseObject.Success)
                            OnSuccesUpdateUser?.Invoke(responseObject.data.message);
                        else
                            OnErrorUpdateUser?.Invoke(responseObject.data.message);
                    }
                }
            }
        }

        public event Action<UsersResponseData.User[]> OnSuccesReadAllUsers;
        public event Action<string> OnErrorReadAllUsers;

        public async void ReadAllUsersAsync()
        {
            using (HttpClient httpClient = new HttpClient { BaseAddress = Uri })
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization", Token);

                using (var response = await httpClient.GetAsync("users"))
                {
                    string responseJson = await response.Content.ReadAsStringAsync();

                    ResponseObject<UsersResponseData> responseObject = ResponseObject.Deserialize<UsersResponseData>(responseJson);

                    if (responseObject.Success)
                        OnSuccesReadAllUsers?.Invoke(responseObject.data.users);
                    else
                        OnErrorReadAllUsers?.Invoke(responseJson);
                }
            }
        }
    }
}
