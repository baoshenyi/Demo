using CoreCRUD.Models;
using CoreCRUD.Models.Business;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCRUD.Data
{
    public class CoreCRUDContext : DbContext, ICoreCRUDContext
    {
        public CoreCRUDContext(DbContextOptions<CoreCRUDContext> options) : base(options)
        {
        }

        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<RaceTrack> RaceTracks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Truck>().ToTable("Truck");
            modelBuilder.Entity<Car>().ToTable("Car");
            modelBuilder.Entity<RaceTrack>().ToTable("RaceTrack");
        }
    }
}
