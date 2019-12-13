using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_End.Models
{
    class Deposite
    {
        public int DepositeID { get; set; }
        public decimal DepositeRate { get; set; }
        public DateTime IssuanceDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public User Investor { get; set; }
    }
}
