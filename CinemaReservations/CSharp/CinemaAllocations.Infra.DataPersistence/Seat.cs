using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaAllocations.Infra.DataPersistence
{
    public class Seat
    {
        public string Id { get; set; }

        public int Number { get; set; }
        
        [ForeignKey("RowId")] 
        public virtual Row Row { get; set; }
    }
}