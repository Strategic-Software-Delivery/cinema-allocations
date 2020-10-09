using Microsoft.EntityFrameworkCore;

namespace CinemaAllocations.Infra.DataPersistence
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        { }
    }
}