using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditApplicationApi.Models
{
    public class CreditApplication
    {
        public int CreditAmount { get; set; }

        public int RepaymentTime { get; set; }

        public int ExistingCreditAmount { get; set; }
    }
}
