

namespace Domain.Requests.ChatRoomUser
{
    public class CreateRoomChatUserRequest
    {
        public int ChatRoomId { get; set; }
        public List<int> UserIds { get; set; }
    }
}
