
namespace Domain.Entities
{
    public class ChatRoomUser : Base
    {
        public int RoomUserId { get; set; }

        public int ChatRoomId { get; set; }

        public ChatRoom ChatRoom { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
    }
}
