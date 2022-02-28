using CreditApplicationApi.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditApplicationApi.Validators
{
    public class CreditApplicationValidator : AbstractValidator<CreditApplication>
    {
        public CreditApplicationValidator()
        {
            RuleFor(ca => ca.CreditAmount).GreaterThanOrEqualTo(2000).WithMessage("Cannot be less than 2000").LessThanOrEqualTo(69000).WithMessage("Cannot be greater than 69000");
            RuleFor(ca => ca.RepaymentTime).GreaterThan(0);
        }
    }
}
