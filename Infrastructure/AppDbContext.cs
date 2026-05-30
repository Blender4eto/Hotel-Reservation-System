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
       => optionsBuilder.UseSqlServer(
           "Data Source=BLENDERTOP\\SQLEXPRESS;Database=CodeFirstDb;Integrated Security=True;TrustServerCertificate=True;");


        public DbSet<Guest> Guests { get; set; }

        //public DbSet<Person> People { get; set; }

        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
                      .HasMaxLength(14);
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

            // Reservation
            //modelBuilder.Entity<Reservation>(entity =>
            //{


            //    entity.Property(r => r.Days)
            //          .IsRequired();
            //    //Reservation -> Guest
            //    entity.HasOne(r => r.Guest)
            //   .WithMany()
            //  .HasForeignKey(r => r.Id);


            //    entity.HasOne(r => r.Room)
            //          .WithMany()
            //          .HasForeignKey(r => r.Id);
            //});

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
