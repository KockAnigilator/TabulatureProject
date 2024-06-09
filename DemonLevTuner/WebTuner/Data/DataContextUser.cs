using Microsoft.EntityFrameworkCore;
using WebTuner.Entity;

namespace WebTuner.Data

{
    public class DataContextUser : DbContext
    {
        public DataContextUser(DbContextOptions<DataContextUser> options) : base(options)
        {

        }

        public DbSet<User> Users => Set<User>();
    }
}