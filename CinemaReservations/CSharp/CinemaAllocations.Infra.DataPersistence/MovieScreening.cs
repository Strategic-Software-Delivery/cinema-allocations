using System.Collections.Generic;

namespace CinemaAllocations.Infra.DataPersistence
{
    public class MovieScreening
    {
        public string Id { get; set; }

        public virtual List<Row> Rows { get; set; }

        public Domain.MovieScreening ToDomainModel()
        {
            throw new System.NotImplementedException();
        }
    }
}