﻿

namespace Domain.Responses.User
{
    public class GetUserByIdResponse
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
