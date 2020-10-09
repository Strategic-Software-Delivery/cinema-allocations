using CinemaAllocations.Domain;
using CinemaAllocations.Infra.DataPersistence;
using Microsoft.EntityFrameworkCore;

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
                    var options = new DbContextOptionsBuilder<CinemaContext>()
                        .UseInMemoryDatabase(databaseName: "CinemaTest")
                        .Options;
                    
                    var cinemaContext = new CinemaContext(options);
                    
                    return new MovieScreeningRepository(cinemaContext);
                }
            }
        }
    }
}