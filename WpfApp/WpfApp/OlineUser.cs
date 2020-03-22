using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    class OlineUser
    {
        private List<User> list;
        public OlineUser()
        {
            list = new List<User>();
        }
        public void AddUser(string name,string email)
        {
            User user = new User(name, email);
            list.Add(user);
        }
        public void Clear()
        {
            if(list.Count>0)
                list.Clear();
        }
        public void Fill()
        {
            for (int i = 0; i < 100; i++)
            {
                list.Add(new User("user" + i, "email@" + i));
            }
        }
        public List<User> GetUsers()
        {
            return list;
        }
        public void FillChat()
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].UChat = new Chat(list[i],"qweqweqweqwe"+i+"asdasdasd");
                if (i > 50)
                    list[i].UChat.AddMessage(list[i - 1], "qweqweqweqwe" + i + "asdasdasd");
                if (i < 50)
                    list[i].UChat.AddMessage(list[i + 1], "qweqweqweqwe" + i + "asdasdasd");
                
                    list[i].UChat.AddMessage(list[i], "qweqweqweqwe" + i + "asdasdasd");
                
                if (i > 50)
                    list[i].UChat.AddMessage(list[i - 1], "qweqweqweqwe" + i + "asdasdasd");
                if (i < 50)
                    list[i].UChat.AddMessage(list[i + 1], "qweqweqweqwe" + i + "asdasdasd");
            }
        }
        public User FindUser(string name)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (name == list[i].Name)
                    return list[i];
                
            }
            return null;
        }
        public User FindUserById(string name)
        {
            string s = "";
            for (int i = 1; i < name.Length; i++)
            {
                s += name[i];
            }
            int tmp = int.Parse(s);
            return list[tmp];
        }
    }
}
