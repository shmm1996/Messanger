using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Chat UChat { get; set; }
        public User(string name,string email)
        {
            Name = name;
            Email = email;
        }
        
    }
}
