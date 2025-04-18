using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("GetUserBy/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await _service.GetUserByIdAsync(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("SearchUsers")]
        public async Task<IActionResult> SearchUsers(string keyword)
        {
            var result = await _service.SearchUsers(keyword);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
