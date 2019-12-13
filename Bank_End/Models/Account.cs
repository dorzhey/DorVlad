using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_End.Models
{
    class Account
    {
        public int AccountID { get; set; }
        public decimal Balanse { get; set; }
        public string Currency { get; set; }
        public User Owner { get; set; }
    }
}
