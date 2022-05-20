using Microsoft.EntityFrameworkCore;

namespace AngularTest.Entities
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ranking> Rankings { get; set; } = null!;

    }
}
