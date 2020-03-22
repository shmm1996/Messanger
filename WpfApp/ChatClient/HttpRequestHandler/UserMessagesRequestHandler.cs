using System;
using System.Net.Http;
using ClientChat.ResponseObjects;

namespace ClientChat.HttpRequestHandler
{
    public class UserMessagesRequestHandler : BaseRequestHandler
    {
        public UserMessagesRequestHandler(string url, string token) : base(url, token) { }

        public event Action<DialogMessage[]> OnSuccesReadUserMessages;
        public event Action<string> OnErrorReadUserMessages;

        public async void ReadUserMessagesAsync()
        {
            using (HttpClient httpClient = new HttpClient { BaseAddress = Uri })
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization", Token);

                using (var response = await httpClient.GetAsync("chat/messages"))
                {
                    string responseJson = await response.Content.ReadAsStringAsync();

                    ResponseObject<DialogMessage[]> responseObject = ResponseObject.Deserialize<DialogMessage[]>(responseJson);

                    if (responseObject.Success)
                        OnSuccesReadUserMessages?.Invoke(responseObject.data);
                    else
                        OnErrorReadUserMessages?.Invoke(responseJson);
                }
            }
        }

        public event Action<DialogMessage[]> OnSuccesReadUsersDialog;
        public event Action<string> OnErrorReadUsersDialog;
        //сука может не работать, нужно документацию смотреть
        public async void ReadUsersDialogAsync(string userName)
        {
            using (HttpClient httpClient = new HttpClient { BaseAddress = Uri })
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization", Token);
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("userName", userName);

                using (var response = await httpClient.GetAsync("chat/dialog"))
                {

                    string responseJson = await response.Content.ReadAsStringAsync();

                    ResponseObject<DialogMessage[]> responseObject = ResponseObject.Deserialize<DialogMessage[]>(responseJson);

                    if (responseObject.Success)
                        OnSuccesReadUsersDialog?.Invoke(responseObject.data);
                    else
                        OnErrorReadUsersDialog?.Invoke(responseJson);
                }
            }
        }

        public event Action<string[]> OnSuccesReadOnlineUsers;
        public event Action<string> OnErrorReadOnlineUsers;
        //предположительно string[] 
        public async void ReadOnlineUsersAsync()
        {
            using (HttpClient httpClient = new HttpClient { BaseAddress = Uri })
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization", Token);

                using (var response = await httpClient.GetAsync("chat/online"))
                {
                    string responseJson = await response.Content.ReadAsStringAsync();

                    ResponseObject<string[]> responseObject = ResponseObject.Deserialize<string[]>(responseJson);

                    if (responseObject.Success)
                        OnSuccesReadOnlineUsers?.Invoke(responseObject.data);
                    else
                        OnErrorReadOnlineUsers?.Invoke(responseJson);
                }
            }
        }
    }
}
