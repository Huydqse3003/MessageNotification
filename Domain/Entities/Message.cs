
namespace Domain.Entities
{
    public class Message : Base
    {
        public int MessageId { get; set; }

        public string Content { get; set; }

        public int ChatRoomId { get; set; }
        public ChatRoom ChatRoom { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public Notification Notification { get; set; }
    }
}
