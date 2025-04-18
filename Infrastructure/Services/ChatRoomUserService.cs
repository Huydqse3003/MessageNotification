using Application;
using Application.IServices;
using AutoMapper;
using Domain.Entities;
using Domain.Requests.ChatRoomUser;
using Domain.Responses;
using Domain.Responses.ChatRoomUser;

namespace Infrastructure.Services
{
    public class ChatRoomUserService : IChatRoomUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChatRoomUserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse> CreateChatRoomUserAsync(CreateRoomChatUserRequest request)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var chatRoom = await _unitOfWork.ChatRooms.GetAsync(cr => cr.ChatRoomId == request.ChatRoomId);
                if (chatRoom == null) return response.SetNotFound(message: "Chat room not found");

                var newRoomUsers = new List<ChatRoomUser>();

                foreach (var userId in request.UserIds)
                {
                    var exists = await _unitOfWork.ChatRoomUsers.GetAsync(cru => cru.ChatRoomId == chatRoom.ChatRoomId && cru.UserId == userId);
                    if (exists == null)
                    {
                        newRoomUsers.Add(new ChatRoomUser
                        {
                            ChatRoomId = chatRoom.ChatRoomId,
                            UserId = userId,

                        });
                    }
                }

                if (newRoomUsers.Any())
                {
                    await _unitOfWork.ChatRoomUsers.AddRangeAsync(newRoomUsers);
                    await _unitOfWork.SaveChangeAsync();
                }
                var result = _mapper.Map<List<ChatRoomUserResponse>>(newRoomUsers);

                return response.SetOk(result);
            }
            catch (Exception ex)
            {
                return response.SetBadRequest(ex.Message);
            }
        }
    }
}
