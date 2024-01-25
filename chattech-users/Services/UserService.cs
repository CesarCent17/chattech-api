using AutoMapper;
using chattech_users.DataSource;
using chattech_users.Interfaces;
using chattech_users.Models.Dto;
using chattech_users.Models.Entities;
using chattech_users.Utils;
using User = chattech_users.Models.User;

namespace chattech_users.Services
{
    public class UserService : IUserService
    {
        private readonly ChattechDbContext _dbContext;
        private readonly IMapper _mapper;
        public UserService(ChattechDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<OperationResult<User>> AddUserAsync(UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);
                user.Password = PasswordManager.HashPassword(user.Password);
                user.JoinDate = DateTime.Now;
                user.IsActive = true;
                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();
                return new OperationResult<User>(true, "The user has been successfully registered", user);
            }
            catch (Exception e)
            {
                return new OperationResult<User>(false, e.Message, null);
            }
        }
    }
}
