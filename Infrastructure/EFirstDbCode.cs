using Hotel_Reservation_System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_System.Infrastructure
{
    internal class EFirstDbCode
    {


        public class AppDbContext : DbContext
        {
            public AppDbContext()
            {

            }

            public AppDbContext(DbContextOptions options) : base(options)
            {
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseSqlServer(
               "Server=(localdb)\\MSSQLLocalDB;Database=CodeFirstDb;Integrated Security=True;");


            public DbSet<Guest> Guests { get; set; }
            public DbSet<Person> People { get; set; }

            public DbSet<Reservation> Reservation { get; set; }

            public DbSet<Room> Rooms{ get; set; }
            public DbSet<Staff> Staffs { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                // Guest
                modelBuilder.Entity<Guest>(entity =>
                {
                    entity.HasKey(g => g.Id);

                    entity.Property(g => g.FirstName)
                          .IsRequired()
                          .HasMaxLength(50);

                    entity.Property(g => g.LastName)
                          .IsRequired()
                          .HasMaxLength(50);

                    entity.Property(g => g.PhoneNumber)
                          .HasMaxLength(14);
                });

                // Staff
                modelBuilder.Entity<Staff>(entity =>
                {
                    entity.HasKey(s => s.Id);

                    entity.Property(s => s.FirstName)
                          .IsRequired()
                          .HasMaxLength(50);

                    entity.Property(s => s.LastName)
                          .IsRequired()
                          .HasMaxLength(50);

                    entity.Property(s => s.Position)
                          .HasMaxLength(50);
                });

                // Room
                modelBuilder.Entity<Room>(entity =>
                {
                    entity.HasKey(r => r.Id);

                    entity.Property(r => r.RoomNumber)
                          .IsRequired();

                    entity.Property(r => r.Price)
                          .HasColumnType("decimal(18,2)");
                });

                // Reservation
                modelBuilder.Entity<Reservation>(entity =>
                {
                    entity.HasKey(r => r.Id);

                    entity.Property(r => r.Days)
                          .IsRequired();

                    // Reservation -> Guest
                    entity.HasOne(r => r.Guest)
                          .WithMany(g => g.Reservations)
                          .HasForeignKey(r => r.GuestId)
                          .OnDelete(DeleteBehavior.Cascade);

                    // Reservation -> Room
                    entity.HasOne(r => r.Room)
                          .WithMany(rm => rm.Reservations)
                          .HasForeignKey(r => r.RoomId)
                          .OnDelete(DeleteBehavior.Restrict);
                });

                // Person (ако е base class)
                modelBuilder.Entity<Person>(entity =>
                {
                    entity.HasKey(p => p.Id);

                    entity.Property(p => p.FirstName)
                          .IsRequired()
                          .HasMaxLength(50);

                    entity.Property(p => p.LastName)
                          .IsRequired()
                          .HasMaxLength(50);
                });
            }
        }
    }
}
