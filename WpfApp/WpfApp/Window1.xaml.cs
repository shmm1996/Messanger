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
using System.Windows.Shapes;

using ClientChat.HttpRequestHandler;
using WpfApp;

namespace UIMessSingIn
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            txtUserNameSignUp.MaxLength = 50;

            string url = "https://immense-brook-86861.herokuapp.com/";

            RegistrationRequestHandler registrationRequestHandler = new RegistrationRequestHandler(url);

            registrationRequestHandler.OnSuccesRegistrate += (token) =>
            {
                WindowsManager.OpenMessangerWindow(token, this);
            };
            registrationRequestHandler.OnErrorRegistrate += (message) =>
            {
                //txtUserNameSignUp.Text = message;
                MessageBox.Show(message);
            };

            btnSingUp.Click += (s, e) =>
            {
                string userName = txtUserNameSignUp.Text;

                if (InputFieldValidator.ValidUserName(userName, out string userNameCallbackMsg))
                {
                    string email = txtEmailSignUp.Text;

                    if (InputFieldValidator.ValidEmail(email, out string emailCallbackMsg))
                    {
                        string password = txtPasswordSignUp.Password;

                        if (InputFieldValidator.ValidPassword(password, out string passwordCallbackMsg))
                        {
                            if (txtRepeatPassword.Password == password)
                                registrationRequestHandler.RegistrateAsync(userName, email, password);
                            else
                            {
                                //err box
                                string str = "RepeatPassword must match Password!";
                                lblRepPassSingUp.Width = str.Length * 5.4;
                                txtRepeatPassword.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 0, 51));
                                lblRepPassSingUp.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                                lblRepPassSingUp.Content = str;

                            }
                        }
                        else
                        {
                            //err box
                            lblPassSingUp.Width = passwordCallbackMsg.Length * 5.4;
                            txtPasswordSignUp.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 0, 51));
                            lblPassSingUp.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                            lblPassSingUp.Content = passwordCallbackMsg;
                        }
                    }
                    else
                    {
                        //err box
                        lblEmeilSingUp.Width = emailCallbackMsg.Length * 5.4;
                        txtEmailSignUp.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 0, 51));
                        lblEmeilSingUp.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                        lblEmeilSingUp.Content = emailCallbackMsg;
                    }
                }
                else
                {
                    //err box
                    lblUNameSingUp.Width = userNameCallbackMsg.Length * 5.4;
                    txtUserNameSignUp.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 0, 51));
                    lblUNameSingUp.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    lblUNameSingUp.Content = userNameCallbackMsg;
                }
            };

            txtRepeatPassword.GotFocus += (s, e) =>
            {
                lblRepPassSingUp.Content = "";
                txtRepeatPassword.BorderBrush = new SolidColorBrush(Color.FromRgb(250, 250, 250));
                lblRepPassSingUp.Background = new SolidColorBrush(Color.FromRgb(248, 248, 250));
            };

            txtPasswordSignUp.GotFocus += (s, e) =>
            {
                lblPassSingUp.Content = "";
                txtPasswordSignUp.BorderBrush = new SolidColorBrush(Color.FromRgb(250, 250, 250));
                lblPassSingUp.Background = new SolidColorBrush(Color.FromRgb(248, 248, 250));
            };

            txtEmailSignUp.GotFocus += (s, e) =>
            {
                lblEmeilSingUp.Content = "";
                txtEmailSignUp.BorderBrush = new SolidColorBrush(Color.FromRgb(250, 250, 250));
                lblEmeilSingUp.Background = new SolidColorBrush(Color.FromRgb(248, 248, 250));
            };

            txtUserNameSignUp.GotFocus += (s, e) =>
            {
                lblUNameSingUp.Content = "";
                txtUserNameSignUp.BorderBrush = new SolidColorBrush(Color.FromRgb(250, 250, 250));
                lblUNameSingUp.Background = new SolidColorBrush(Color.FromRgb(248, 248, 250));
            };



            btnLoginPage.Click += (s, e) => WindowsManager.OpenLoginWindow(this);

            txtUserNameSignUp.Focus();
        }
    }
}
