using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_End.Models
{
    public class Deposit
    {   // Я знаю, что правильно deposit*, позндно заметил ошибку, много где менять ещё надо  
        public long DepositID { get; set; }
        public int Regularity { get; set; }
        public decimal DepositRate { get; set; }
        public DateTime IssuanceDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public User Investor { get; set; }
    }
}
