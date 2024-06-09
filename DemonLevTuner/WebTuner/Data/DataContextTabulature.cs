using Microsoft.EntityFrameworkCore;
using WebTuner.Entity;

namespace WebTuner.Data

{
    public class DataContextTabulature : DbContext
    {
        public DataContextTabulature(DbContextOptions<DataContextTabulature> options) : base(options)
        {

        }

        public DbSet<Tabulature> Songs => Set<Tabulature>();
    }
}
