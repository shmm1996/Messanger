using System.Windows;

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

            string[] dataLogin = email.Split('@'); // делим строку на две части
            if (dataLogin.Length == 2) // проверяем если у нас две части
            {
                string[] data2Login = dataLogin[1].Split('.'); // делим вторую часть ещё на две части
                if (data2Login.Length == 2)
                {

                }
                else MessageBox.Show("Email in the format ****@*.*");
            }
            else MessageBox.Show("Email in the format ****@*.*");

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
