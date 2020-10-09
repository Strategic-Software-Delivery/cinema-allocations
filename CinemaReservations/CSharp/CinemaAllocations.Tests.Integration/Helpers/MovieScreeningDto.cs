using System.Collections.Generic;
using CinemaAllocations.Infra.DataPersistence;

namespace CinemaAllocations.Tests.Integration.Helpers
{
    public class MovieScreeningDto
    {
        public Dictionary<string, IReadOnlyList<SeatDto>> Rows { get; set; }

        internal MovieScreening ToDataModel()
        {
            throw new System.NotImplementedException();
        }
    }
}