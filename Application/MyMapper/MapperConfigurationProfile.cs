using AutoMapper;
using Domain.Entities;
using Domain.Requests.ChatRoom;
using Domain.Responses.ChatRoom;
using Domain.Responses.ChatRoomUser;
using Domain.Responses.User;

namespace Application.MyMapper
{
    public class MapperConfigurationProfile : Profile
    {
        public MapperConfigurationProfile() 
        {
            //User
            CreateMap<User, SearchUserResponse>();
            CreateMap<User, GetUserByIdResponse>();

            //ChatRoom
            CreateMap<ChatRoom, ChatRoomResponse>();
            CreateMap<CreateRoomChatRequest, ChatRoom>();

            //ChatRoomUser
            CreateMap<ChatRoomUser, ChatRoomUserResponse>();
        }
    }
}
