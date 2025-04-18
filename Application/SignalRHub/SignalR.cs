using Microsoft.AspNetCore.SignalR;
using Domain.Entities;

namespace Application.SignalR
{
    public class SignalR : Hub
    {
        private readonly IUnitOfWork _unitOfWork;
        public SignalR(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task OnConnectedAsync()
        {
            var userId = Context.UserIdentifier;

            if (int.TryParse(userId, out int id))
            {
                var user = await _unitOfWork.Users.GetAsync(u => u.UserId == id);
                if (user != null)
                {
                    user.IsOnline = true;
                    await _unitOfWork.SaveChangeAsync();
                }
                
            } 

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? ex)
        {
            var userId = Context.UserIdentifier;
            if (int.TryParse(userId, out int id))
            {
                var user = await _unitOfWork.Users.GetAsync(u => u.UserId == id);
                if (user != null)
                {
                    user.IsOnline = false;
                    user.LastOnline = DateTime.UtcNow;
                    await _unitOfWork.SaveChangeAsync();
                }
            }

            await base.OnDisconnectedAsync(ex);
        }

        public async Task AddUserIdToRoomChat(string userId = "", string roomChatId = "")
        {
            if (string.IsNullOrEmpty(userId) && string.IsNullOrEmpty(roomChatId))
            {
                await Clients.Caller.SendAsync("Error", "Thiếu thông tin user hoặc phòng.");
                return;
            }

            var isIntegerRoomChat = int.TryParse(roomChatId, out var roomId);
            var isIntegerUser = int.TryParse(userId, out var id);
            if (!isIntegerRoomChat || !isIntegerUser)
            {
                await Clients.Caller.SendAsync("Error", "UserId hoặc RoomId không hợp lệ.");
                return;
            }

            var roomChat = await _unitOfWork.ChatRooms.GetAsync(cr => cr.ChatRoomId == roomId);
            if (roomChat == null)

            {
                await Clients.Caller.SendAsync("Error", "Phòng chat không tồn tại.");
                return;
            }

            var user = await _unitOfWork.Users.GetAsync(u => u.UserId == id);
            if (user == null)
            {
                await Clients.Caller.SendAsync("Error", "Người dùng không tồn tại.");
                return;
            }

            var chatRoomUser = await _unitOfWork.ChatRoomUsers.AnyAsync(cru => cru.UserId == id && cru.ChatRoomId == roomId);
            if (!chatRoomUser)
            {
                await _unitOfWork.ChatRoomUsers.AddAsync(new ChatRoomUser
                {
                    ChatRoomId = roomId,
                    UserId = id,
                });

                _unitOfWork.SaveChangeAsync();

                await JoinRoom(roomChatId, userId);
            }
        }

        public async Task JoinRoom(string groupId, string userId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupId);

            await Clients.Group(groupId).SendAsync("UserJoined", userId);
        }
    }
}
