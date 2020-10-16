using System.Collections.Generic;

namespace CinemaAllocations.Tests.Acceptance.Helpers.Dto
{
    public class SeatsAllocated
    {
        public int PartyRequested { get; set; }

        public List<Seat> ReservedSeats { get; set; }
    }
}