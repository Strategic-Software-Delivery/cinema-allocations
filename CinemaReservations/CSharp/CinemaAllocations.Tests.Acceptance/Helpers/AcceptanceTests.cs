using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace CinemaAllocations.Tests.Acceptance.Helpers
{
    public abstract class AcceptanceTests : IClassFixture<ApiWebApplicationFactory>
    {
        protected readonly ApiWebApplicationFactory _factory;
        protected readonly HttpClient _client;
        protected readonly IConfiguration _configuration;

        protected AcceptanceTests(ApiWebApplicationFactory fixture)
        {
            _factory = fixture;
            _client = _factory.CreateClient();
            // _configuration = new ConfigurationBuilder()
            //     .AddJsonFile("integrationsettings.json")
            //     .Build();
        }
    }
}