using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditApplicationApi.Models
{
    public class CreditDecision
    {
        public int CreditAmount { get; set; }

        public int RepaymentTime { get; set; }

        public int InterestRate { get; set; }
    }
}
