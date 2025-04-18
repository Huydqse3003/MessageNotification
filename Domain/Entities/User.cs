namespace Domain.Entities
{
    public class User : Base
    {
        public int UserId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool? IsEmailVerified { get; set; } = false;
        public string? ImgUrl { get; set; }
        public Role Role { get; set; }

        public bool IsOnline { get; set; } = false;

        public DateTime? LastOnline { get; set; }
        public List<ChatRoomUser>? ChatRoomUsers { get; set; }

        public List<Notification>? Notifications { get; set; }

        public List<Message>? Messages { get; set; }
    }

    public enum Role
    {
        Customer,
        Admin,
        Staff
    }
}
