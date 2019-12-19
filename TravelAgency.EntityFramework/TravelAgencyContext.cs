using System.Data.Entity;
using TravelAgency.DataAccessLayer.Entities;

namespace TravelAgency.EntityFramework
{
    public class TravelAgencyContext : DbContext
    {
        public TravelAgencyContext() : base("TravelAgency")
        {
        }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Food> Food { get; set; }

        public DbSet<HotelType> HotelTypes { get; set; }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<TourType> TourTypes { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Tour> Tours { get; set; }

        public DbSet<TourPage> TourPages { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Food>().ToTable("Food");

            modelBuilder.Entity<Tour>().Property(p => p.Nights).HasColumnName("NumberOfNights");
            modelBuilder.Entity<Tour>().Property(p => p.Days).HasColumnName("NumberOfDays");
        }
    }
}
