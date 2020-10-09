using System.Collections.Generic;

namespace CinemaAllocations.Infra.DataPersistence
{
    public class MovieScreening
    {
        public int Id { get; set; }

        public virtual List<Row> Rows { get; set; }
    }
}