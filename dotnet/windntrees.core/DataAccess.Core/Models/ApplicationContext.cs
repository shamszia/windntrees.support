using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Core.Models
{
    public partial class ApplicationContext : DbContext
    {
        public virtual DbSet<ActivityHistory> ActivityHistory { get; set; }
        public virtual DbSet<Advertisement> Advertisement { get; set; }
        public virtual DbSet<AdvertisementLocation> AdvertisementLocation { get; set; }
        public virtual DbSet<AdvertisementPage> AdvertisementPage { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<CompanyType> CompanyType { get; set; }
        public virtual DbSet<Configuration> Configuration { get; set; }
        public virtual DbSet<LicenseInfo> LicenseInfo { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductFeature> ProductFeature { get; set; }
        public virtual DbSet<Reference> Reference { get; set; }
        public virtual DbSet<Registration> Registration { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=127.0.0.1\sqlexpress01;Database=windntrees_core;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivityHistory>(entity =>
            {
                entity.Property(e => e.Uid).ValueGeneratedNever();

                entity.Property(e => e.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<Advertisement>(entity =>
            {
                entity.Property(e => e.Uid).ValueGeneratedNever();

                entity.Property(e => e.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<AdvertisementLocation>(entity =>
            {
                entity.Property(e => e.Uid).ValueGeneratedNever();

                entity.Property(e => e.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<AdvertisementPage>(entity =>
            {
                entity.Property(e => e.Uid).ValueGeneratedNever();

                entity.Property(e => e.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Uid).ValueGeneratedNever();

                entity.Property(e => e.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.Property(e => e.Uid).ValueGeneratedNever();

                entity.Property(e => e.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Uid).ValueGeneratedNever();
            });

            modelBuilder.Entity<CompanyType>(entity =>
            {
                entity.Property(e => e.Uid).ValueGeneratedNever();
            });

            modelBuilder.Entity<Configuration>(entity =>
            {
                entity.Property(e => e.Uid).ValueGeneratedNever();

                entity.Property(e => e.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<LicenseInfo>(entity =>
            {
                entity.Property(e => e.ProductId).ValueGeneratedNever();

                entity.Property(e => e.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.Property(e => e.Uid).ValueGeneratedNever();

                entity.Property(e => e.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Uid).ValueGeneratedNever();

                entity.Property(e => e.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<ProductFeature>(entity =>
            {
                entity.HasIndex(e => e.ProductId);

                entity.Property(e => e.Uid).ValueGeneratedNever();
            });

            modelBuilder.Entity<Reference>(entity =>
            {
                entity.Property(e => e.Uid).ValueGeneratedNever();
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.Property(e => e.Uid).ValueGeneratedNever();

                entity.Property(e => e.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.Property(e => e.Uid).ValueGeneratedNever();

                entity.Property(e => e.RowVersion).IsRowVersion();
            });
        }
    }
}
