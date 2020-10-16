namespace CinemaAllocations.Infra.RestApi.Dto
{
    public class Seat
    {
        public Seat(Domain.Seat seat)
        {
            RowName = seat.RowName;
            Number = seat.Number;
        }
        
        public string RowName { get; }
        public uint Number { get; }
    }
}