using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Login
    {
        public string _username { get; set; }
        public string _password { get; set; }

        public Login(string s1, string s2)
        {
            _username = s1;
            _password = s2;
        }

    }
}
