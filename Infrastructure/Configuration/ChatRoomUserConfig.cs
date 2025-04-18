

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class ChatRoomUserConfig : IEntityTypeConfiguration<ChatRoomUser>
    {
        public void Configure(EntityTypeBuilder<ChatRoomUser> builder)
        {
            builder.HasKey(cru => cru.RoomUserId);
            builder.HasOne(cru => cru.User)
                .WithMany(cru => cru.ChatRoomUsers)
                .HasForeignKey(cru => cru.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(cru => cru.ChatRoom)
                .WithMany(cru => cru.ChatRoomUsers)
                .HasForeignKey(cru => cru.ChatRoomId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
