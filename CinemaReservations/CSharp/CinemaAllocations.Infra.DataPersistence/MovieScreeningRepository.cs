using CinemaAllocations.Domain;

namespace CinemaAllocations.Infra.DataPersistence
{
    public class MovieScreeningRepository : IMovieScreeningRepository
    {
        public Domain.MovieScreening FindMovieScreeningById(string screeningId)
        {
            throw new System.NotImplementedException();
        }
    }
}