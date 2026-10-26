using Microsoft.EntityFrameworkCore;
using WeatherApplication.Model;

namespace WeatherApplication.Repository.DBContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<customers> customers { get; set; }
        public DbSet<transation> transation { get; set; }
    }
}
