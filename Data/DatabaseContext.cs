using LushNailBar.Models;
using Microsoft.EntityFrameworkCore;

namespace LushNailBar.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }

        public DbSet<Service> Service { get; set; }
    }
}