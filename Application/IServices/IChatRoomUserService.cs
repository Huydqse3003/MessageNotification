

using Domain.Requests.ChatRoomUser;
using Domain.Responses;

namespace Application.IServices
{
    public interface IChatRoomUserService
    {
        Task<ApiResponse> CreateChatRoomUserAsync(CreateRoomChatUserRequest request);
    }
}
