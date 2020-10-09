using System.Collections.Generic;

namespace CinemaAllocations.Tests.Integration.Helpers
{
    public class MovieScreeningDto
    {
        public Dictionary<string, IReadOnlyList<SeatDto>> Rows { get; set; }
    }
}