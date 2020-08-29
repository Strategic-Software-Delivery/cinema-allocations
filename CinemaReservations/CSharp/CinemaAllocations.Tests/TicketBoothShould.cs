using CinemaAllocations.Domain;
using CinemaAllocations.Tests.StubMovieScreening;
using NFluent;
using Xunit;

namespace CinemaAllocations.Tests
{
    public class SeatsAllocatorShould
    {
        [Fact]
        public void Reserve_one_seat_when_available()
        {
            const string showId = "1";
            const int partyRequested = 1;

            IMovieScreeningRepository repository = new StubMovieScreeningRepository();
            TicketBooth ticketBooth = new TicketBooth(repository);

            var seatsAllocated = ticketBooth.AllocateSeats(new AllocateSeats(showId, partyRequested));

            Check.That(seatsAllocated.ReservedSeats).HasSize(1);
            Check.That(seatsAllocated.ReservedSeats[0].ToString()).IsEqualTo("A3");
        }

        [Fact]
        public void Return_SeatsNotAvailable_when_all_seats_are_unavailable()
        {
            const string showId = "5";
            const int partyRequested = 1;

            IMovieScreeningRepository repository = new StubMovieScreeningRepository();
            TicketBooth ticketBooth = new TicketBooth(repository);

            var seatsAllocated = ticketBooth.AllocateSeats(new AllocateSeats(showId, partyRequested));

            Check.That(seatsAllocated).IsInstanceOf<NoPossibleAllocationsFound>();
        }

        [Fact]
        public void Return_TooManyTicketsRequested_when_9_tickets_are_requested()
        {
            const string showId = "5";
            const int partyRequested = 9;

            IMovieScreeningRepository repository = new StubMovieScreeningRepository();
            TicketBooth ticketBooth = new TicketBooth(repository);

            var seatsAllocated = ticketBooth.AllocateSeats(new AllocateSeats(showId, partyRequested));
            
            Check.That(seatsAllocated).IsInstanceOf<TooManyTicketsRequested>();

        }
    }
}