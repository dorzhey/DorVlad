using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_End.Models
{
    public class Card
    {
        public long CardNumber { get; set; }
        public Account CardAccount { get; set; }

    }
}
