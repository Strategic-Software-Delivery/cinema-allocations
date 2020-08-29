using System.Collections.Generic;

namespace CinemaAllocations.Domain
{
    public class SeatAllocation
    {
        public int PartyRequested { get; }
        public List<Seat> AllocatedSeats { get; } = new List<Seat>();
        public bool IsFulfilled => AllocatedSeats.Count == PartyRequested;

        public SeatAllocation(int partyRequested)
        {
            this.PartyRequested = partyRequested;
        }

        public void AddSeat(Seat seat)
        {
            AllocatedSeats.Add(seat);
        }
    }
}