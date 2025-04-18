

using Domain.Requests.User;
using Domain.Responses;

namespace Application.IServices
{
    public interface IUserService
    {
        Task<ApiResponse> LoginAsync(LoginRequest request);
        Task<ApiResponse> GetUserByIdAsync(int id);
        Task<ApiResponse> SearchUsers(string keyword);
        Task<ApiResponse> RegisterAsync(RegisterRequest request);
    }
}
