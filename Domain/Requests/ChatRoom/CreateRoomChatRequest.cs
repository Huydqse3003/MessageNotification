

namespace Domain.Requests.ChatRoom
{
    public class CreateRoomChatRequest
    {
        public string ChatRoomName { get; set; }

        public List<int> UserIds { get; set; }

    }
}
