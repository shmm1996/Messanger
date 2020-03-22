using System.Windows;

using UIMessSingIn;

namespace WpfApp
{
    public static class WindowsManager
    {

        public static void OpenLoginWindow(Window s = null)
        {
            new MainWindow().Show();
            s?.Close();
        }

        public static void OpenRegistrationWindow(Window s = null)
        {
            new Window1().Show();
            s?.Close();
        }

        public static void OpenMessangerWindow(string userName, string email, string token, Window s = null)
        {
            new WindowPageChat(userName, email, token).Show();
            s?.Close();
        }

    }
}
