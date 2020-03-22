using System;

namespace ClientChat.ResponseObjects
{

    [Serializable]
    public class UsersResponseData
    {
        private UsersResponseData() { }
        public User[] users { get; set; }

        [Serializable]
        public class User
        {
            private User() { }
            public string userName { get; set; }
            public string email { get; set; }
        }
    }
}
