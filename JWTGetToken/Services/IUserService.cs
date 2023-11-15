using JWTGetToken.DTOs;
using JWTGetToken.Entities;

namespace JWTGetToken.Services
{
    public interface IUserService
    {
        public ValueTask<IList<User>> GetAllUsers();
        public ValueTask<bool> CreateUser(UserDTO userDTO);
    }
}
