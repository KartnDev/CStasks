using Microsoft.EntityFrameworkCore;
using SecSemTask3.Models;

namespace SecSemTask3.Database
{
    public sealed class AppContext : DbContext
    {
        private readonly string _serverName;
        public DbSet<UserModel> Users { get; set; }

        public AppContext(string serverName)
        {
            _serverName = serverName;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                $"Server={_serverName};Database=MobileDB;Trusted_Connection=True;");
        }
    }
}