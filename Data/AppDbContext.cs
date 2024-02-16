using crud_system.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
namespace crud_system.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base(options)
        {
            
        }
        public DbSet<Models.Type> types { set; get; }
        public DbSet<Blog> blogs { set; get; }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
       modelBuilder.Entity< Models.Type>().HasData(
                 new Models.Type { Id = 1, Name = "Romantic" },
                 new Models.Type { Id = 2, Name = "Action" });
         }
       
    }
}
