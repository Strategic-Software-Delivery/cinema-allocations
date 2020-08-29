using System.Collections.Generic;

namespace CinemaAllocations.Domain
{
    public class MovieScreening
    {
        public IReadOnlyDictionary<string, Row> Rows => _rows;
        
        private readonly Dictionary<string, Row> _rows;

        public MovieScreening(Dictionary<string, Row> rows)
        {
            _rows = rows;
        }

        public SeatsAllocated AllocateSeats(AllocateSeats allocateSeats)
        {
            foreach( var row in _rows.Values) {
                SeatsAllocated seatsAllocated = row.AllocateSeats(allocateSeats);
                if (seatsAllocated.GetType() != typeof(NoPossibleAllocationsFound)) {
                    Row updatedRow = row.MakeSeatsReserved(seatsAllocated.ReservedSeats);
                    _rows[updatedRow.Name] =  updatedRow;
                    return seatsAllocated;
                }
            }
            return new NoPossibleAllocationsFound(allocateSeats.PartyRequested);
        }
    }
}