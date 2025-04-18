
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class ChatRoomConfig : IEntityTypeConfiguration<ChatRoom>
    {
        public void Configure(EntityTypeBuilder<ChatRoom> builder)
        {
            builder.HasKey(cr => cr.ChatRoomId);
            builder.HasMany(cr => cr.ChatRoomUsers)
                .WithOne(cr => cr.ChatRoom)
                .HasForeignKey(cr => cr.ChatRoomId);
            builder.HasMany(cr => cr.Messages)
                .WithOne(cr => cr.ChatRoom)
                .HasForeignKey(cr => cr.ChatRoomId);
        }
    }
}
