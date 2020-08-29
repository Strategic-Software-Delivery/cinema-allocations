

using System;

namespace CinemaAllocations.Domain
{
    public class TicketBooth 
    {
        private IMovieScreeningRepository _screeningRepository;

        public TicketBooth(IMovieScreeningRepository repo)
        {
            _screeningRepository = repo;
        }

        public SeatsAllocated AllocateSeats(AllocateSeats allocateSeats)
        {
            MovieScreening movieScreening = _screeningRepository.FindMovieScreeningById(allocateSeats.ShowId);
            return null;
        }

    }
}