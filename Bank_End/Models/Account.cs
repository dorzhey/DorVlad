using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_End.Models
{
    public class Account
    {
        public int AccountID { get; set; }
        public decimal Balanse { get; set; }
        public int Currency { get; set; }
        public User Owner { get; set; }
    }
}
