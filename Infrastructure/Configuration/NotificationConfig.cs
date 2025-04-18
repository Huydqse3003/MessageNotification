

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class NotificationConfig : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(n => n.NotificationId);
            builder.HasOne(n => n.User)
                .WithMany(n => n.Notifications)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(n => n.Message)
                .WithOne(n => n.Notification)
                .HasForeignKey<Notification>(n => n.MessageId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Property(n => n.Content)
                .IsRequired()
                .HasMaxLength(1000);
        }
    }
}
