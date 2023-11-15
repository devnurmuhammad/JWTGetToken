using JWTGetToken.DataAccess;
using JWTGetToken.DTOs;
using JWTGetToken.Entities;
using JWTtoken.Services.Security;
using Microsoft.EntityFrameworkCore;

namespace JWTGetToken.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;
        private readonly ITokenService _tokenService;

        public UserService(AppDbContext dbContext, ITokenService tokenService)
        {
            _dbContext = dbContext;
            _tokenService = tokenService;
        }

        public async ValueTask<bool> CreateUser(UserDTO userDTO)
        {
            User user = new User();
            user.UserName = userDTO.UserName;
            user.PasswordHash = Hash512.ComputeHash512(userDTO.PasswordHash);
            await _dbContext.Users.AddAsync(user);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async ValueTask<IList<User>> GetAllUsers()
        {
            IList<User> result = await _dbContext.Users.ToListAsync();
            return result;
        }
    }
}
