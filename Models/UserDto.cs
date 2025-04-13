namespace CRUD_API.Models
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = "User"; // Optional, defaults to User
    }
}
