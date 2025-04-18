

using Application.IRepositories;

namespace Application
{
    public interface IUnitOfWork
    {
        public IUserRepository Users { get; }
        public IChatRoomRepository ChatRooms { get; }
        public IChatRoomUserRepository ChatRoomUsers { get; }

        Task SaveChangeAsync();
    }
}
