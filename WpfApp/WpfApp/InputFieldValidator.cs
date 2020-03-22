namespace WpfApp
{
    public static class InputFieldValidator
    {
        public static bool ValidUserName(string userName)
        {
            if (userName == null)
                return false;

            if (userName.Length < 4)
                return false;

            return true;
        }

        public static bool ValidEmail(string email)
        {
            if (email == null)
                return false;

            return true;
        }

        public static bool ValidPassword(string password)
        {
            if (password == null)
                return false;

            if (password.Length < 4)
                return false;

            return true;
        }
    }
}
