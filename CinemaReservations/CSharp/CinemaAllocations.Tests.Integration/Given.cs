using CinemaAllocations.Domain;
using CinemaAllocations.Infra.DataPersistence;

namespace CinemaAllocations.Tests.Integration
{
    internal static class Given
    {
        internal static class A
        {
            internal static IMovieScreeningRepository ChangeNameCinema
            {
                get
                {
                    return new MovieScreeningRepository(new CinemaContext(null));
                }
            }
        }
    }
}