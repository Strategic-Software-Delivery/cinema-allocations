using CinemaAllocations.Domain;
using NFluent;
using Xunit;

namespace CinemaAllocations.Tests.Integration
{
    public class TicketBoothShould
    {
        [Fact]
        public void Reserve_one_seat_when_available()
        {
            const int partyRequested = 1;
            
            IMovieScreeningRepository repository = Given.The.FordTheater;
            TicketBooth ticketBooth = new TicketBooth(repository);
            
            var seatsAllocated = ticketBooth.AllocateSeats(new AllocateSeats(Given.The.FordTheaterId, partyRequested));
            
            Check.That(seatsAllocated.ReservedSeats).HasSize(1);
            Check.That(seatsAllocated.ReservedSeats[0].ToString()).IsEqualTo("A3");
        }
    }
}