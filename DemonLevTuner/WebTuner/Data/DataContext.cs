using Microsoft.EntityFrameworkCore;
using WebTuner.Entity;

namespace WebTuner.Data

{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Song> Songs => Set<Song>();
        public DbSet<Tabulature> Tabulatures => Set<Tabulature>();
    }
}