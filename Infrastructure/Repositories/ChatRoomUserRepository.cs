

using Application.IRepositories;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class ChatRoomUserRepository : GenericRepository<ChatRoomUser>, IChatRoomUserRepository
    {
        public ChatRoomUserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
