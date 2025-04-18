
namespace Domain.Entities
{
    public class Notification : Base
    {
        public int NotificationId { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; } = false;

        public int UserId { get; set; }

        public User User { get; set; }

        public int MessageId { get; set; }
        public Message Message { get; set; }

    }
}
