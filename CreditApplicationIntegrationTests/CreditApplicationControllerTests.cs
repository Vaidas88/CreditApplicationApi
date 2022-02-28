using CreditApplicationApi.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace CreditApplicationIntegrationTests
{
    public class CreditApplicationControllerTests
    {
        private WebApplicationFactory<Program> _application;

        private HttpClient _client;

        public CreditApplicationControllerTests()
        {
            _application = new WebApplicationFactory<Program>();
            _client = _application.CreateClient();
        }

        [Fact]
        public async Task Test()
        {
            var creditApplication = new CreditApplication()
            {
                CreditAmount = 50000,
                ExistingCreditAmount = 0,
                RepaymentTime = 12
            };

            var result = await _client.PostAsJsonAsync("/creditapplication", creditApplication);

            result.EnsureSuccessStatusCode();

            var creditDecision = await result.Content.ReadAsAsync<CreditDecision>();

            creditDecision.Should().BeEquivalentTo(new CreditDecision()
            {
                CreditAmount = 50000,
                RepaymentTime = 12,
                InterestRate = 5
            });
        }
    }
}