

using Domain.Entities;

namespace Application.IRepositories
{
    public interface IChatRoomRepository : IGenericRepository<ChatRoom>
    {
        Task<List<ChatRoom>> GetListChatRooms(int userId);
    }
}
