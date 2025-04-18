using Application;
using Application.IServices;
using AutoMapper;
using Domain.Entities;
using Domain.Requests.ChatRoom;
using Domain.Responses;
using Domain.Responses.ChatRoom;

namespace Infrastructure.Services
{
    public class ChatRoomService : IChatRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
        public ChatRoomService(IUnitOfWork unitOfWork, IMapper mapper, IClaimService claimService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _claimService = claimService;
        }

        public async Task<ApiResponse> CreateNewRoomChat(CreateRoomChatRequest request) 
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var claim = _claimService.GetUserClaim();
                var chatRoom = _mapper.Map<ChatRoom>(request);
                await _unitOfWork.ChatRooms.AddAsync(chatRoom);
                await _unitOfWork.SaveChangeAsync();

                var roomUsers = new List<ChatRoomUser>();
                foreach (var userId in request.UserIds)
                {
                    var exists = await _unitOfWork.ChatRoomUsers.GetAsync(cru => cru.ChatRoomId == chatRoom.ChatRoomId && cru.UserId == userId);
                    if (exists == null)
                    {
                        roomUsers.Add(new ChatRoomUser
                        {
                            ChatRoomId = chatRoom.ChatRoomId,
                            UserId = userId,
                        });
                    }
                }
                return response.SetOk(chatRoom.ChatRoomId);
            }
            catch (Exception ex)
            {
                return response.SetBadRequest(ex.Message);
            }
        }

        public async Task<ApiResponse> GetListRoomChat()
        {
            ApiResponse response = new ApiResponse();
            var claim = _claimService.GetUserClaim();
            var chatRooms = await _unitOfWork.ChatRooms.GetListChatRooms(claim.UserId);

            var responseList = _mapper.Map<List<ChatRoomResponse>>(chatRooms);

            return response.SetOk(responseList);
        }

    }
}
