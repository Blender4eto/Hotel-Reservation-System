using Hotel_Reservation_System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_System.Infrastructure
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
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=BLENDERTOP\\SQLEXPRESS;Database=CodeFirstDb1;Integrated Security=True;TrustServerCertificate=True;Encrypt=False;");
            }
        }


        public DbSet<Guest> Guests { get; set; }

        public DbSet<Person> People { get; set; }
        public DbSet<ReservationService> ReservationServices { get; set; }

        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>()
               .ToTable("People");

            modelBuilder.Entity<Guest>()
                .ToTable("Guests");

            modelBuilder.Entity<Staff>()
                .ToTable("Staffs");

            // Guest
            modelBuilder.Entity<Guest>(entity =>
            {


                entity.Property(g => g.FirstName)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(g => g.LastName)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(g => g.PhoneNumber)
                      .IsRequired();
            });

            // Staff
            modelBuilder.Entity<Staff>(entity =>
            {


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


                entity.Property(r => r.RoomNumber)
                      .IsRequired();

                entity.Property(r => r.Price)
                      .HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.Property(r => r.Days)
                      .IsRequired();

                // Reservation -> Guest
                entity.HasOne(r => r.Guest)
                      .WithMany()
                      .HasForeignKey(r => r.GuestId);

                // Reservation -> Room
                entity.HasOne(r => r.Room)
                      .WithMany()
                      .HasForeignKey(r => r.RoomId);

               
            
            });
            modelBuilder.Entity<ReservationService>(entity =>
            {
                entity.HasOne(s => s.Reservation)
                      .WithMany(r => r.Services)
                      .HasForeignKey(s => s.ReservationId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });
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
