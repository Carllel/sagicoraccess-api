using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sagicor.Access.Identity.Models;

namespace Sagicor.Access.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                 new ApplicationUser
                 {
                     Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                     Email = "admin@sagicor.com",
                     NormalizedEmail = "ADMIN@SAGICOR.COM",
                     FirstName = "System",
                     LastName = "Admin",
                     UserName = "admin@sagicor.com",
                     NormalizedUserName = "ADMIN@SAGICOR.COM",
                     PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                     EmailConfirmed = true
                 },
                 new ApplicationUser
                 {
                     Id = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                     Email = "user@sagicor.com",
                     NormalizedEmail = "USER@SAGICOR.COM",
                     FirstName = "System",
                     LastName = "User",
                     UserName = "user@sagicor.com",
                     NormalizedUserName = "USER@SAGICOR.COM",
                     PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                     EmailConfirmed = true
                 }
            );
        }
    }
}
