namespace WpfApp
{
    public static class InputFieldValidator
    {
        public static bool ValidUserName(string userName, out string callbackMsg)
        {
            callbackMsg = null;

            if (userName == null)
            {
                callbackMsg = "Username can`t be empty!";
                return false;
            }

            if (userName.Length < 4)
            {
                callbackMsg = "Username length can`t be less then 4!";
                return false;
            }

            return true;
        }

        public static bool ValidEmail(string email, out string callbackMsg)
        {
            callbackMsg = null;

            if (email == null)
            {
                callbackMsg = "Email can`t be empty!";
                return false;
            }

            return true;
        }

        public static bool ValidPassword(string password, out string callbackMsg)
        {
            callbackMsg = null;

            if (password == null)
            {
                callbackMsg = "Password can`t be empty!";
                return false;
            }

            if (password.Length < 4)
            {
                callbackMsg = "Password length can`t be less then 4!";
                return false;
            }

            return true;
        }
    }
}
