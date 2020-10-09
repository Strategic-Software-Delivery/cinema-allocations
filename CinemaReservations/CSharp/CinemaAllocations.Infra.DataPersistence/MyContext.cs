using Microsoft.EntityFrameworkCore;

namespace CinemaAllocations.Infra.DataPersistence
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        public DbSet<MovieScreening> MovieScreenings { get; set; }
        public DbSet<Row> Rows { get; set; }
    }
}