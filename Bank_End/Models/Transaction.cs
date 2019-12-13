using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_End.Models
{
    class Transaction
    {
        public int TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public User Sender { get; set; }
        public User Reciever { get; set; }
    }
}
