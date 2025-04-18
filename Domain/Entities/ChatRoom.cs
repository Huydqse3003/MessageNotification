

namespace Domain.Entities
{
    public class ChatRoom : Base
    {
        public int ChatRoomId { get; set; }

        public string ChatRoomName { get; set; }

        public List<ChatRoomUser> ChatRoomUsers { get; set; }

        public List<Message>? Messages { get; set; }
    }
}
