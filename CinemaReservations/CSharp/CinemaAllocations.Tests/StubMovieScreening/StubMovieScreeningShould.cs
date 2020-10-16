using CinemaAllocations.Domain;
using NFluent;
using NUnit.Framework;

namespace CinemaAllocations.Tests.StubMovieScreening
{
    [TestFixture]
    public class StubMovieScreeningShould
    {
        [Test]
        public void Find_movie_screening_one()
        {
            IMovieScreeningRepository repository = new StubMovieScreeningRepository();

            var movieScreening = repository.FindMovieScreeningById("1");

            Check.That(movieScreening).IsNotNull();
            Check.That(movieScreening.Rows.Count).IsEqualTo(2);
        }
    }
}