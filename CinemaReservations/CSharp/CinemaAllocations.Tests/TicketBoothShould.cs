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

            Check.That(seatsAllocated.ReservedSeats).HasSize(1);
            Check.That(seatsAllocated.ReservedSeats[0].ToString()).IsEqualTo("A3");
        }
        
        [Test]
        public void Reserve_multiple_seats_when_available()
        {
            const string showId = "3";
            const int partyRequested = 3;

            IMovieScreeningRepository repository = new StubMovieScreeningRepository();
            TicketBooth ticketBooth = new TicketBooth(repository);

            var seatsAllocated = ticketBooth.AllocateSeats(new AllocateSeats(showId, partyRequested));

            Check.That(seatsAllocated.ReservedSeats).HasSize(3);
            Check.That(seatsAllocated.SeatNames()).ContainsExactly("A6", "A7", "A8");
        }

        [Test]
        public void Return_SeatsNotAvailable_when_all_seats_are_unavailable()
        {
            const string showId = "5";
            const int partyRequested = 1;

            IMovieScreeningRepository repository = new StubMovieScreeningRepository();
            TicketBooth ticketBooth = new TicketBooth(repository);

            var seatsAllocated = ticketBooth.AllocateSeats(new AllocateSeats(showId, partyRequested));

            Check.That(seatsAllocated).IsInstanceOf<NoPossibleAllocationsFound>();
        }

        [Test]
        public void Return_TooManyTicketsRequested_when_9_tickets_are_requested()
        {
            const string showId = "5";
            const int partyRequested = 9;

            IMovieScreeningRepository repository = new StubMovieScreeningRepository();
            TicketBooth ticketBooth = new TicketBooth(repository);

            var seatsAllocated = ticketBooth.AllocateSeats(new AllocateSeats(showId, partyRequested));
            
            Check.That(seatsAllocated).IsInstanceOf<TooManyTicketsRequested>();

        }
        
        [Test]
        public void reserve_three_adjacent_seats_when_available()
        {
            const string showId = "2";
            const int partyRequested = 3;

            IMovieScreeningRepository repository = new StubMovieScreeningRepository();
            TicketBooth ticketBooth = new TicketBooth(repository);

            var seatsAllocated = ticketBooth.AllocateSeats(new AllocateSeats(showId, partyRequested));
            
            Check.That(seatsAllocated.ReservedSeats).HasSize(3);
            Check.That(seatsAllocated.SeatNames()).ContainsExactly("A8", "A9", "A10");

        }
        
        [Test]
        public void return_NoPossibleAdjacentSeatsFound_when_4_tickets_are_requested()
        {
            const string showId = "2";
            const int partyRequested = 4;

            IMovieScreeningRepository repository = new StubMovieScreeningRepository();
            TicketBooth ticketBooth = new TicketBooth(repository);

            var seatsAllocated = ticketBooth.AllocateSeats(new AllocateSeats(showId, partyRequested));
            
            Check.That(seatsAllocated).IsInstanceOf<NoPossibleAdjacentSeatsFound>();
        }
    }
}