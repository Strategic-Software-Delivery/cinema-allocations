using System.Net;
using System.Threading.Tasks;
using CinemaAllocations.Tests.Acceptance.Helpers;
using Newtonsoft.Json;
using NFluent;
using Xunit;

namespace CinemaAllocations.Tests.Acceptance
{
    public class MovieScreeningControllerShould : AcceptanceTests
    {
        public MovieScreeningControllerShould(ApiWebApplicationFactory fixture)
            : base(fixture)
        {
        }

        [Fact]
        public async Task Reserve_one_seat_when_available()
        {
            // The solution started here: https://timdeschryver.dev/blog/how-to-test-your-csharp-web-api you need to do some magic to inject the DB. ;)

            var response = await _client.PostAsync($"/moviescreening/{Given.The.FordTheaterId}/allocateseats/1", null);
            Check.That(response.StatusCode).IsEqualTo(HttpStatusCode.OK);

            var seatsAllocated =
                JsonConvert.DeserializeObject<Infra.RestApi.Dto.SeatsAllocated>(
                    await response.Content.ReadAsStringAsync());
            Check.That(seatsAllocated.ReservedSeats).HasSize(1);
        }
    }
}