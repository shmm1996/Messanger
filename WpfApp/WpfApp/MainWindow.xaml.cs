using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using ClientChat.HttpRequestHandler;
using WpfApp;

namespace UIMessSingIn
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            string url = "https://immense-brook-86861.herokuapp.com/";

            AuthorizationRequestHandler authorizationRequestHandler = new AuthorizationRequestHandler(url);

            authorizationRequestHandler.OnSuccesAuthorize += (token) =>
            {
                WindowsManager.OpenMessangerWindow(token, this);
            };
            authorizationRequestHandler.OnErrorAuthorize += (message) =>
            {
                txtUserNameSignIn.Text = message;
            };

            btnSignIn.Click += (s, e) =>
            {
                string userName = txtUserNameSignIn.Text;

                if (InputFieldValidator.ValidUserName(userName))
                {
                    string password = txtPasswordSignIn.Text;

                    if (InputFieldValidator.ValidPassword(password))
                    {
                        authorizationRequestHandler.AuthorizeAsync(userName, password);
                    }
                }
            };

            btnRegisterAccount.Click += (s, e) => WindowsManager.OpenRegistrationWindow(this);
        }
    }
}
