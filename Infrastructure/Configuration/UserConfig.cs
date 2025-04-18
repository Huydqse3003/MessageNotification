using Domain.DTOs;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography;

namespace Infrastructure.Configuration
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserId);
            builder.HasMany(u => u.Notifications)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId);
            builder.HasMany(u => u.ChatRoomUsers)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId);

            var user1 = CreatePasswordHash("User1");
            var user2 = CreatePasswordHash("User2");
            var employer = CreatePasswordHash("User3");
            var admin = CreatePasswordHash("Admin");

            builder.HasData
               (
                 new User
                 {
                     UserId = 1,
                     PasswordHash = user1.PasswordHash,
                     PasswordSalt = user1.PasswordSalt,
                     LastName = "User1",
                     Role = Role.Customer,
                     Email = "User1@gmail.com",
                     IsEmailVerified = true
                 },
                 new User
                 {
                     UserId = 2,
                     PasswordHash = user2.PasswordHash,
                     PasswordSalt = user2.PasswordSalt,
                     LastName = "User2",
                     Role = Role.Customer,
                     Email = "User2@gmail.com",
                     IsEmailVerified = true
                 },
                 new User
                 {
                     UserId = 3,
                     PasswordHash = employer.PasswordHash,
                     PasswordSalt = employer.PasswordSalt,
                     LastName = "Employer",
                     Role = Role.Customer,
                     Email = "Employer@gmail.com",
                     IsEmailVerified = true
                 },
                 new User
                 {
                     UserId = 4,
                     PasswordHash = admin.PasswordHash,
                     PasswordSalt = admin.PasswordSalt,
                     LastName = "Admin",
                     Role = Role.Admin,
                     Email = "Admin@gmail.com",
                     IsEmailVerified = true
                 }
               );
        }



        private PasswordDTO CreatePasswordHash(string password)
        {
            PasswordDTO pass = new PasswordDTO();
            using (var hmac = new HMACSHA512())
            {
                pass.PasswordSalt = hmac.Key;
                pass.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            return pass;
        }
    }
}
