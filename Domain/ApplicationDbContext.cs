using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Excursion> Excursions { get; set; }

        public DbSet<Place> Places { get; set; }

        public DbSet<PlaceVisit> PlaceVisits { get; set; }

        public DbSet<PointOfInterest> PointOfInterests { get; set; }

        public DbSet<PointOfInterestVisit> PointOfInterestVisits { get; set; }

        public DbSet<Tourist> Tourists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Reference Data

            modelBuilder.Entity<Place>().HasData(new Place { Id = 1, Name = "Paris", PlaceType = PlaceType.Capital });
            modelBuilder.Entity<Place>().HasData(new Place { Id = 2, Name = "Berlin", PlaceType = PlaceType.Capital });
            modelBuilder.Entity<Place>().HasData(new Place { Id = 3, Name = "Nice", PlaceType = PlaceType.City });

            modelBuilder.Entity<PointOfInterest>().HasData(new PointOfInterest { Id = 1, Name = "Louvre", PlaceId = 1 });
            modelBuilder.Entity<PointOfInterest>().HasData(new PointOfInterest { Id = 2, Name = "Eiffel Tower", PlaceId = 1 });
            modelBuilder.Entity<PointOfInterest>().HasData(new PointOfInterest { Id = 3, Name = "Reichstag", PlaceId = 2 });
        }
    }
}