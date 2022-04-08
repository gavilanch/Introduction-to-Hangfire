using IntroToHangfire.Entities;
using Microsoft.EntityFrameworkCore;

namespace IntroToHangfire
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> People => Set<Person>();
    }
}
