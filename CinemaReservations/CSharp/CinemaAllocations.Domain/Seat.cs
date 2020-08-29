using System;
using System.Collections.Generic;
using Value;

namespace CinemaAllocations.Domain
{
    public class Seat : ValueType<Seat>
    {
        public string RowName { get; }
        public uint Number { get; }
        
        public SeatAvailability SeatAvailability { get; }
        
        public Seat(string rowName, uint number, SeatAvailability seatAvailability)
        {
            RowName = rowName;
            Number = number;
            SeatAvailability = seatAvailability;
        }

        public Seat reserveSeats()
        {
            return new Seat(RowName, Number, SeatAvailability.Reserved);
        }

        public Boolean isAvailable()
        {
            return SeatAvailability == SeatAvailability.Available;
        }

        public Boolean sameSeatLocation(Seat seat)
        {
            return RowName.Equals(seat.RowName) && Number == seat.Number;
        }
        
        public override string ToString()
        {
            return $"{RowName}{Number}";
        }
        
        
        protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality()
        {
            return new object[] { RowName, Number, SeatAvailability };
        }
    }
}