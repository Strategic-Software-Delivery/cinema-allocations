using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaAllocations.Infra.DataPersistence
{
    public class Seat
    {
        public string Name { get; set; }

        public string Availability { get; set; }
        
        [ForeignKey("RowId")] 
        public virtual Row Row { get; set; }
    }
}