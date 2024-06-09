using Microsoft.EntityFrameworkCore;
using WebTuner.Entity;

namespace WebTuner.Data

{
    public class DataContextSong : DbContext
    {
        public DataContextSong(DbContextOptions<DataContextSong> options) : base(options) 
        {

        }

        public DbSet<Song> Songs => Set<Song>(); 
    }
}
