using Domain.Requests.ChatRoom;
using Domain.Responses;

namespace Application.IServices
{
    public interface IChatRoomService
    {
        Task<ApiResponse> CreateNewRoomChat(CreateRoomChatRequest request);

        Task<ApiResponse> GetListRoomChat();
    }
}
