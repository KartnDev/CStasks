using Microsoft.EntityFrameworkCore;
using SecSemTask3.Models;
using Microsoft.EntityFrameworkCore;

namespace SecSemTask3.Database
{
    public sealed class AppContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }

        public AppContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=<НАЗВАНИЕ БД ТУТ>;Trusted_Connection=True;");
        }
    }
}