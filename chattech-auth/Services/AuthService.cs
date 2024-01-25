using chattech_auth.DataSource;
using chattech_auth.Interface;
using chattech_auth.Interfaces;
using chattech_auth.Models.Dto;
using chattech_auth.Models.Entities;
using chattech_auth.Utils;
using Microsoft.EntityFrameworkCore;

namespace chattech_auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly ChattechDbContext _dbContext;
        private readonly ITokenService _tokenService;
        public AuthService(ChattechDbContext dbContext, ITokenService tokenService) 
        {
            _dbContext = dbContext;
            _tokenService = tokenService;
        }

        public async Task<OperationResult<string>> Login(AuthRequest authRequest)
        {
            var user = await _dbContext.Users.Where(u => u.UserName == authRequest.UserName && u.IsActive).FirstOrDefaultAsync();

            if (user == null || !PasswordManager.VerifyPassword(user.Password, authRequest.Password))
            {
                return new OperationResult<string>(false, "Incorrect username or password", null);
            }

            string token = _tokenService.GenerateToken(user.Id.ToString(), user.UserName);
            return new OperationResult<string>(true, "Successful login", token);
        }
    }
}
