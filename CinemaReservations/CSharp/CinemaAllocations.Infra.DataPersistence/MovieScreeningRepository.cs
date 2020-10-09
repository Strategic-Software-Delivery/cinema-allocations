using System;
using CinemaAllocations.Domain;

namespace CinemaAllocations.Infra.DataPersistence
{
    public class MovieScreeningRepository : IMovieScreeningRepository
    {
        private readonly CinemaContext _myContext;

        public MovieScreeningRepository(CinemaContext myContext)
        {
            _myContext = myContext ?? throw new ArgumentNullException(nameof(myContext));
        }
        public Domain.MovieScreening FindMovieScreeningById(string screeningId)
        {
            throw new System.NotImplementedException();
        }
    }
}