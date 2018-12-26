using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Application.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string Title { get; set; }
        public string ImageFile { get; set; }
        public string Package { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public string ApprovedBy { get; set; }

        public static User FromDataAccessUser(DataAccess.User user)
        {
            return new User {
                AccessFailedCount = user.AccessFailedCount,
                ApprovedBy = user.ApprovedBy,
                CreationDate = user.CreationDate,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                ExpiryDate = user.ExpiryDate,
                FirstName = user.FirstName,
                Id = user.UserId,
                IsApproved = user.IsApproved,
                ImageFile = user.ImageFile,
                LastName = user.LastName,
                LockoutEnabled = user.LockoutEnabled,
                LockoutEndDateUtc = user.LockoutEndDateUtc,
                Package = user.Package,
                PasswordHash = user.PasswordHash,
                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                SecurityStamp = user.SecurityStamp,
                Sex = user.Sex,
                Title = user.Title,
                TwoFactorEnabled = user.TwoFactorEnabled,
                UserName = user.UserName
            };
        }
    }

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("User").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim").Property(p => p.Id).HasColumnName("ClaimId");
            modelBuilder.Entity<IdentityRole>().ToTable("Role").Property(p => p.Id).HasColumnName("RoleId");
        }
    }
}