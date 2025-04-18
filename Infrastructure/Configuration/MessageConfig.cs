

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class MessageConfig : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(m => m.MessageId);
            builder.HasOne(m => m.Notification)
                  .WithOne(m => m.Message)
                  .HasForeignKey<Notification>(n => n.MessageId)
                  .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(m => m.User)
                .WithMany(m => m.Messages)
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(m => m.ChatRoom)
                .WithMany(m => m.Messages)
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Property(m => m.Content)
                   .IsRequired()
                   .HasMaxLength(1000);
        }
    }
}
