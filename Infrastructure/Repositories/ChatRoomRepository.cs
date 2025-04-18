

using Domain.Entities;
using Application.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ChatRoomRepository : GenericRepository<ChatRoom>, IChatRoomRepository
    {
        public ChatRoomRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<ChatRoom>> GetListChatRooms(int userId)
        {
            IQueryable<ChatRoom> query = _context.ChatRooms
                .Include(cr => cr.ChatRoomUsers)
                .Where(cr => cr.ChatRoomUsers.Any(cru => cru.UserId == userId))
                .Select(cr => new ChatRoom
                {
                    ChatRoomId = cr.ChatRoomId,
                    ChatRoomName = cr.ChatRoomName
                });

            return await query.ToListAsync();    
        }
    }
}
