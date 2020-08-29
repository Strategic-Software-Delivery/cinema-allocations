using CinemaAllocations.Domain;
using CinemaAllocations.Tests.StubMovieScreening;
using NFluent;
using NUnit.Framework;

namespace CinemaAllocations.Tests
{
    [TestFixture]
    public class SeatsAllocatorShould
    {
        [Test]
        public void Reserve_one_seat_when_available()
        {
            const string showId = "1";
            const int partyRequested = 1;

            IMovieScreeningRepository repository = new StubMovieScreeningRepository();
            TicketBooth ticketBooth = new TicketBooth(repository);

            var seatsAllocated = ticketBooth.AllocateSeats(new AllocateSeats(showId, partyRequested));

            Check.That(seatsAllocated.Seats).HasSize(1);
            Check.That(seatsAllocated.Seats[0].ToString()).IsEqualTo("A3");
        }

        [Test]
        public void Return_SeatsNotAvailable_when_all_seats_are_unavailable()
        {
            Check.That(true).Equals(false);
        }

        [Test]
        public void Return_TooManyTicketsRequested_when_9_tickets_are_requested()
        {
            Check.That(true).Equals(false);
        }
    }
}