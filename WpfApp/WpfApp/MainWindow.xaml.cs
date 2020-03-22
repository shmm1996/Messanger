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
                //txtUserNameSignIn.Text = message;
                MessageBox.Show(message);
            };

            btnSignIn.Click += (s, e) =>
            {
                string userName = txtUserNameSignIn.Text;

                if (InputFieldValidator.ValidUserName(userName, out string userNameCallbackMsg))
                {
                    string password = txtPasswordSignIn.Password;

                    if (InputFieldValidator.ValidPassword(password, out string passwordCallbackMsg))
                    {
                        authorizationRequestHandler.AuthorizeAsync(userName, password);
                    }
                    else
                    {
                        //err box
                        lblPasswSingIn.Width = passwordCallbackMsg.Length * 5.4;
                        txtPasswordSignIn.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 0, 51));
                        lblPasswSingIn.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                        lblPasswSingIn.Content = passwordCallbackMsg;

                    }
                }
                else
                {
                    //err box                    
                    lblUNameSingIn.Width = userNameCallbackMsg.Length * 5.4;
                    txtUserNameSignIn.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 0, 51));
                    lblUNameSingIn.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    lblUNameSingIn.Content = userNameCallbackMsg;

                }
            };

            txtPasswordSignIn.GotFocus += (s, e) =>
            {                
                lblPasswSingIn.Content = "";
                txtPasswordSignIn.BorderBrush = new SolidColorBrush(Color.FromRgb(250,250,250));
                lblPasswSingIn.Background = new SolidColorBrush(Color.FromRgb(248, 248, 250));                
            };

            txtUserNameSignIn.GotFocus += (s, e) =>
            {
                lblUNameSingIn.Content = "";
                txtUserNameSignIn.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                lblUNameSingIn.Background = new SolidColorBrush(Color.FromRgb(248, 248, 250));                
            };

            btnRegisterAccount.Click += (s, e) => WindowsManager.OpenRegistrationWindow(this);

            txtUserNameSignIn.Focus();
        }
    }
}

