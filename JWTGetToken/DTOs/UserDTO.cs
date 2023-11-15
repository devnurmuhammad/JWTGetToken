namespace JWTGetToken.DTOs
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
    }
}
