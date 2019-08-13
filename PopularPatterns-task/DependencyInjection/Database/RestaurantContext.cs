using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DependencyInjection.Database
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(string connectionString)
            : this(new DbContextOptionsBuilder<RestaurantContext>()
                .UseSqlServer(connectionString)
                .Options)
        {
        }

        public RestaurantContext(DbContextOptions<RestaurantContext> options)
            : base(options)
        {
        }

        public DbSet<Table> Tables { get; private set; }
        public DbSet<Shift> Shifts { get; private set; }
        public DbSet<Reservation> Reservations { get; private set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);

            // By default all strings are mapped to nullable nvarchar(max) column type.

            model.Entity<Table>()
                .Property(t => t.Name)
                    .IsRequired()
                    .HasMaxLength(100);

            model.Entity<Shift>()
                .Property(t => t.Name)
                    .IsRequired()
                    .HasMaxLength(100);

            model.Entity<Reservation>()
                .Property(t => t.ReserverName)
                    .IsRequired()
                    .HasMaxLength(100);

            // EF Core 2.x does not support many-to-many relationships without an explicit 
            // linking type, hence the use of TableAssignment.

            // Composite keys are not inferred by default, so we have to specify those
            // explicitly

            model.Entity<TableAssignment>()
                .HasKey(t => new { t.ReservationId, t.TableId });
        }
    }

    public class Table
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Shift
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan StartsAt { get; set; }
        public TimeSpan EndsAt { get; set; }
    }

    public class Reservation
    {
        public Reservation()
        {
            TableAssignments = new List<TableAssignment>();
        }

        public int Id { get; set; }
        public DateTime ReservationTime { get; set; }
        public string ReserverName { get; set; }
        public virtual ICollection<TableAssignment> TableAssignments { get; set; }
    }

    public class TableAssignment
    {
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }
    }
}
