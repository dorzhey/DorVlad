using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_End.Models
{
    class User
    {
        public int UserID { get; private set; }
        public string Name { get; set; }
        private int _password;

        private int Password
        {
            get { return _password; }
            set { _password = value; }
        }
    }
}
