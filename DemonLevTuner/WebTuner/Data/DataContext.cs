using Microsoft.EntityFrameworkCore;

namespace WebTuner.Data

{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }

        public DbSet<RpgClass> rpg => Set<RpgClass>(); 
    }
}
