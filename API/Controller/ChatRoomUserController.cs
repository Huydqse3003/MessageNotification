using Application.IServices;
using Domain.Requests.ChatRoomUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatRoomUserController : ControllerBase
    {
        private readonly IChatRoomUserService _service;

        public ChatRoomUserController(IChatRoomUserService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateChatRoomUser(CreateRoomChatUserRequest request)
        {
            var result = await _service.CreateChatRoomUserAsync(request);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
