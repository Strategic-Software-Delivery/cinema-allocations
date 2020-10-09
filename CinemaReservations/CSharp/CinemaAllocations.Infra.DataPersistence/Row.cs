using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaAllocations.Infra.DataPersistence
{
    public class Row
    {
        public int Id { get; set; }

        [ForeignKey("MovieScreeningId")]
        public MovieScreening MovieScreening { get; set; }
    }
}