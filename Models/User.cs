namespace CRUD_API.Models
{
    public class User
    {
        public int Id { get; set; }
        
        public string Username { get; set; }

        public string PasswordHash { get; set; }  // Store hashed password securely

        public string Role { get; set; } = "User"; // Default value


    }
}
