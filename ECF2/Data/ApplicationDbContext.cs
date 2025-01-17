using ECF2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ECF2.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Participant> Participants { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Participant>().HasData
                (
                    new Participant()
                    {
                        Id = 1,
                        LastName = "Dupont",
                        FirstName = "Childéric",
                        Email = "childeric.dupont@mail.com",
                        Phone = "0123456789"
                    },
                    new Participant()
                    {
                        Id = 2,
                        LastName = "Martin",
                        FirstName = "Méroflède",
                        Email = "merofledemartin@aliceadsl.fr",
                        Phone = "0102030405"
                    },
                    new Participant()
                    {
                        Id = 3,
                        LastName = "Martin",
                        FirstName = "Brunehilde",
                        Email = "brunehilde666@hotmail.com",
                        Phone = "0836656565"
                    }
                );
            modelBuilder.Entity<Event>().HasData
                (
                new Event()
                {
                    Id = 1,
                    Title = "Titre 1",
                    Description = "Description 1",
                    EventTypeId = 2,
                    StartDate = new DateTime(2025, 01, 25),
                    EndDate = new DateTime(2025, 01, 25).AddHours(2),
                    Address = "123 rue de AAA, 59000 Lille"

                },
                new Event()
                {
                    Id = 2,
                    Title = "Titre 2",
                    Description = "Description 2",
                    EventTypeId = 1,
                    StartDate = new DateTime(2025, 02, 1),
                    EndDate = new DateTime(2025, 02, 1).AddHours(3),
                    Address = "La Civette, Le Cateau-Cambrésis"
                }
                );
            modelBuilder.Entity<EventType>().HasData
                (
                new EventType()
                {
                    Id = 1,
                    Type = "bar mitzvah"
                },
                new EventType()
                {
                    Id = 2,
                    Type = "funérailles"
                }
                );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSnakeCaseNamingConvention();
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            // Remove the pluralization convention for the table names
            configurationBuilder.Conventions.Remove(typeof(TableNameFromDbSetConvention));
            // Second precision (instead of fractional)
            configurationBuilder.Properties<DateTime>().HavePrecision(0);
        }
    }

}
