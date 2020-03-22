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
            string url = "https://immense-brook-86861.herokuapp.com/";

            RegistrationRequestHandler registrationRequestHandler = new RegistrationRequestHandler(url);

            registrationRequestHandler.OnSuccesRegistrate += (token) => {

                //WindowPageChat windowChat = new WindowPageChat();
                //windowChat.Show();
                //this.Close();

                txtUserNameSignUp.Text = token;
            };
            registrationRequestHandler.OnErrorRegistrate += (message) => {
                txtUserNameSignUp.Text = message;
            };

            btnSingUp.Click += (s, e) =>
            {
                string userName = txtUserNameSignUp.Text;

                if (InputFieldValidator.ValidUserName(userName))
                {
                    string email = txtEmailSignUp.Text;

                    if (InputFieldValidator.ValidEmail(email))
                    {
                        string password = txtPasswordSignUp.Text;

                        if (InputFieldValidator.ValidPassword(password))
                        {
                            if (txtRepeatPassword.Text == password)
                                registrationRequestHandler.RegistrateAsync(userName, email, password);

                        }
                    }
                }
            };

            btnLoginPage.Click += (s, e) => WindowsManager.OpenLoginWindow(this);
        }
    }
}
