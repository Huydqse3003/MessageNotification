

using Application.IServices;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Domain.DTOs;

namespace Infrastructure.Services
{
    public class ClaimService : IClaimService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClaimService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimDTO GetUserClaim()
        {
            var tokenUserId = _httpContextAccessor.HttpContext!.User.FindFirst("UserId");
            var tokenUserRole = _httpContextAccessor.HttpContext!.User.FindFirst("Role");
            if (tokenUserId == null)
            {
                throw new ArgumentNullException("UserId can not be found!");
            }
            var userId = Int32.Parse(tokenUserId?.Value.ToString()!);
            Role role = Enum.Parse<Role>(tokenUserRole?.Value.ToString()!);
            var userClaim = new ClaimDTO
            {
                Role = role,
                UserId = userId
            };

            return userClaim;
        }
    }
}
