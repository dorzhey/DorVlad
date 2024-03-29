﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_End.Models
{
    public class Credit
    {
        public long CreditID { get; set; }
        public int Regularity { get; set; }
        public decimal CreditRate { get; set; }
        public DateTime IssuanceDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public User Borrower { get; set; }
    }
}
