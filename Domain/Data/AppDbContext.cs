using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Data
{
    public class AppDbContext : DbContext
    {
        private const string ConnectionString =
            @"Server=(localdb)\mssqllocaldb;
            Database=NorthWind;
            Trusted_Connection=True";

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // public AppDbContext(DbContextOptions<AppDbContext> options)
        //     : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(ConnectionString);
        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Customer>();
        //     modelBuilder.Entity<Purchase>();
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");
                entity.Property(p => p.Name).IsRequired();
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.ToTable("Purchase");
                entity.Property(p => p.Date).IsRequired();
                entity.Property(p => p.Description).IsRequired();
            });
        }
    }
}
