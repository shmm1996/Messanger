using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    class Chat
    {

        public List<Message> message=new List<Message>();
        public Chat(User user,string str)
        {
            message.Add(new Message(user,str));

        }
        public void AddMessage(User from,string mes)
        {
            message.Add(new Message(from, mes));
        }
        public List<Message> GetMessages()
        {
            return message;
        }
        
    }
    class Message
    {
        private DateTime time;
        private string message;
        private User from;
        public Message(User user,string str)
        {
            time = DateTime.Now;
            message = str;
            from = user;
        }
        public DateTime GetTime()
        {
            return time;
        }
        public string GetMes()
        {
            return message;
        }
        public string GetFrom()
        {
            return from.Name;
        }
    }
}
