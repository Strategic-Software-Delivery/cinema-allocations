﻿namespace CinemaAllocations.Tests.Integration.Helpers
{
    public class SeatDto
    {
        public SeatDto(string name, string seatAvailability)
        {
            Name = name;
            SeatAvailability = seatAvailability;
        }

        public string Name { get; }
        public string SeatAvailability { get; }
        
    }
}