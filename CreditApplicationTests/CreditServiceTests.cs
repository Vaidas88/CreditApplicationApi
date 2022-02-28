using CreditApplicationApi.Models;
using CreditApplicationApi.Services;
using Xunit;
using FluentAssertions;
using System;

namespace CreditApplicationTests
{
    public class CreditServiceTests
    {
        private CreditService _creditService;

        public CreditServiceTests()
        {
            _creditService = new CreditService();
        }

        [Fact]
        public void GetInterestRate_ShouldReturnInterestRateBasedOnSuppliedCreditAmount()
        {
            int interestRate = _creditService.GetInterestRate(20000);

            Assert.Equal(4, interestRate);
        }

        [Fact]
        public void MakeDecision_ShouldReturnCreditDecision()
        {
            CreditApplication creditApplication = new CreditApplication()
            {
                CreditAmount = 50000,
                ExistingCreditAmount = 0,
                RepaymentTime = 5
            };

            CreditDecision expectedCreditDecision = new CreditDecision()
            {
                CreditAmount = 50000,
                RepaymentTime = 5,
                InterestRate = 5
            };

            CreditDecision actualCreditDecision = _creditService.MakeDecision(creditApplication);

            expectedCreditDecision.Should().BeEquivalentTo(actualCreditDecision);
        }

        [Fact]
        public void IsCreditApplicationValid_ShouldReturnTrueForValidApplication()
        {
            CreditApplication creditApplication = new CreditApplication()
            {
                CreditAmount = 50000,
                ExistingCreditAmount = 0,
                RepaymentTime = 5
            };

            bool isCreditApplicationValid = _creditService.IsCreditApplicationValid(creditApplication);

            isCreditApplicationValid.Should().Be(true);
        }

        [Fact]
        public void IsCreditApplicationValid_ShouldThrowExceptionForInvalidApplication()
        {
            CreditApplication creditApplication = new CreditApplication()
            {
                CreditAmount = 0,
                ExistingCreditAmount = 0,
                RepaymentTime = 0
            };

            Action act = () => _creditService.IsCreditApplicationValid(creditApplication);

            act.Should().Throw<FluentValidation.ValidationException>();
        }

        [Fact]
        public void GetDecision_ShouldReturnDecisionForCreditApplication()
        {
            CreditApplication creditApplication = new CreditApplication()
            {
                CreditAmount = 50000,
                ExistingCreditAmount = 0,
                RepaymentTime = 5
            };

            CreditDecision expectedCreditDecision = new CreditDecision()
            {
                CreditAmount = 50000,
                RepaymentTime = 5,
                InterestRate = 5
            };

            CreditDecision actualCreditDecision = _creditService.GetDecision(creditApplication);

            expectedCreditDecision.Should().BeEquivalentTo(actualCreditDecision);
        }

        [Fact]
        public void GetDecision_ShouldThrowExceptionForInvalidCreditApplication()
        {
            CreditApplication creditApplication = new CreditApplication()
            {
                CreditAmount = 0,
                ExistingCreditAmount = 0,
                RepaymentTime = 0
            };

            Action act = () => _creditService.GetDecision(creditApplication);

            act.Should().Throw<FluentValidation.ValidationException>();
        }
    }
}