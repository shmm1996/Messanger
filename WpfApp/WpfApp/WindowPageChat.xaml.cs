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
using WpfApp;
using ClientChat.HttpRequestHandler;
using ClientChat.ResponseObjects;
using System.Threading;


namespace UIMessSingIn
{
    
    public partial class WindowPageChat : Window
    {
        OlineUser olineUser = new OlineUser();
        string url = "https://immense-brook-86861.herokuapp.com/";
        string tokenn;
        UsersRequestHandler usersRequestHandler;

        public WindowPageChat(string token)
        {
            tokenn = token;

            InitializeComponent();

            btnExit.Click += (s, e) => Environment.Exit(0);

            ReqOnlineUsers();
            RefreshChat();

        }

        private void btnPanelPeople_Click(object sender, RoutedEventArgs e)
        {
            btnChatPanel.Opacity = 100;
            btnChatPeople.Opacity = 60;
            btnChatSetting.Opacity = 100;
        }

        private void btnPanelSetting_Click(object sender, RoutedEventArgs e)
        {
            btnChatPeople.Opacity = 100;
            btnChatSetting.Opacity = 50;            
            WindowProfile windowProfile = new WindowProfile();
            windowProfile.Show();
            this.Close();
        }

        private string ClearName(string str)
        {
            string tmp = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != '\"')
                    tmp += str[i];
            }
            return tmp;
        }
        private string ClearName2(string str)
        {
            string tmp = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                    break;
                else
                    tmp += str[i];
            }
            return tmp;
        }
        private void ReqOnlineUsers()
        {
            usersRequestHandler = new UsersRequestHandler(url, tokenn);

            usersRequestHandler.OnSuccesReadAllUsers += (users) =>
            {

                //olineUser.Clear();
                foreach (UsersResponseData.User user in users)
                {

                    olineUser.AddUser(ClearName(user.userName), ClearName(user.email));
                }
            };
            //new Thread(new ThreadStart(() =>
            //{
            //    RefreshChat();
            //    Thread.Sleep(10000);
            //})).Start();
        }

        public void RefreshChat()
        {
            usersRequestHandler.ReadAllUsersAsync();
            AddUsers();
        }


        public void AddUsers()
        {
            //olineUser.Fill();
            //olineUser.Clear();
            OnlineList.Children.Clear();

            for (int i = 0; i < olineUser.GetUsers().Count; i++)
            {
                OnlineList.Children.Add(CreateUI(olineUser.GetUsers()[i], i));
            }
            olineUser.FillChat();

        }
        private UIElement CreateUI(User user, int i)
        {
            Button but = new Button();
            but.Content = user.Name + "\n\t\t" + user.Email;
            but.Height = 50;
            but.Name = 'b' + i.ToString();
            but.Click += CreateChat;
            SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(20, 70, 106));
            but.Background = brush;
            return but;
        }
        private void CreateChat(object sender, RoutedEventArgs e)
        {
            chat.Children.Clear();
            chat.Children.Add(Messeges(olineUser.FindUserById(((Button)e.Source).Name)));
        }

        private UIElement Messeges(User user)
        {
            StackPanel sp = new StackPanel();
            sp.Orientation = Orientation.Vertical;
            StackPanel messag = new StackPanel();
            TextBox lab;
            for (int i = 0; i < user.UChat.GetMessages().Count; i++)
            {
                messag = new StackPanel();
                lab = new TextBox();
                lab.Text = user.UChat.GetMessages()[i].GetFrom() + "\t" + user.UChat.GetMessages()[i].GetTime() + "\n" + user.UChat.GetMessages()[i].GetMes();
                lab.Width = 500;
                //Border border = new Border();
                //border.CornerRadius = new CornerRadius(5);

                if (user.UChat.GetMessages()[i].GetFrom() == user.Name)
                {
                    messag.HorizontalAlignment = HorizontalAlignment.Right;
                    lab.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    lab.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));

                }

                else
                {
                    messag.HorizontalAlignment = HorizontalAlignment.Left;
                    lab.Background = new SolidColorBrush(Color.FromRgb(20, 70, 106));
                    lab.BorderBrush = new SolidColorBrush(Color.FromRgb(20, 70, 106));
                    lab.Foreground = Brushes.White;
                }

                messag.Children.Add(lab);
                sp.Children.Add(messag);
            }

            return sp;
        }



        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            RefreshChat();
        }
    }
}
