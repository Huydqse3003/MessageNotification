

using Domain.Entities;

namespace Domain.DTOs
{
    public class ClaimDTO
    {
        public int UserId { get; set; }
        public Role Role { get; set; }
    }
}
