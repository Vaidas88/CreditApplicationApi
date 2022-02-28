using CreditApplicationApi.Models;
using CreditApplicationApi.Validators;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditApplicationApi.Services
{
    public class CreditService
    {
        public CreditDecision GetDecision(CreditApplication creditApplication)
        {
            CreditDecision creditDecision = new CreditDecision();

            if (IsCreditApplicationValid(creditApplication))
            {
                creditDecision = MakeDecision(creditApplication);
            }

            return creditDecision;
        }

        public bool IsCreditApplicationValid(CreditApplication creditApplication)
        {
            CreditApplicationValidator validator = new CreditApplicationValidator();
            validator.ValidateAndThrow(creditApplication);

            return true;
        }

        public CreditDecision MakeDecision(CreditApplication creditApplication)
        {
            CreditDecision creditDecision = new CreditDecision();

            creditDecision.CreditAmount = creditApplication.CreditAmount;
            creditDecision.RepaymentTime = creditApplication.RepaymentTime;
            creditDecision.InterestRate = GetInterestRate(creditApplication.CreditAmount);

            return creditDecision;
        }

        public int GetInterestRate(int creditAmount)
        {
            if (creditAmount < 20000)
            {
                return 3;
            }
            if (creditAmount >= 20000 && creditAmount < 40000)
            {
                return 4;
            }
            if (creditAmount >= 40000 && creditAmount < 60000)
            {
                return 5;
            }
            if (creditAmount >= 60000)
            {
                return 6;
            }

            return 0;
        }
    }
}
