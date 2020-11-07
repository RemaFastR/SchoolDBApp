using Microsoft.EntityFrameworkCore;
using SchoolDBApp;

namespace SchoolDBApp
{
    public class SchoolDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=SchoolDB.db");
        }
        public DbSet<SchoolDBApp.Student> Student { get; set; }
    }
}
