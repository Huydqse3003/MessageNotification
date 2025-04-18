
using Application.IServices;
using Domain.Requests.ChatRoom;
using Domain.Requests.ChatRoomUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatRoomController : ControllerBase
    {
        private readonly IChatRoomService _service;

        public ChatRoomController(IChatRoomService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateNewChatRoom(CreateRoomChatRequest request)
        {
            var result = await _service.CreateNewRoomChat(request);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetListChatRoom()
        {
            var response = await _service.GetListRoomChat();
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
    }
}
