using chattech_users.Models;
using chattech_users.Models.Dto;
using chattech_users.Models.Entities;

namespace chattech_users.Interfaces
{
    public interface IUserService
    {
        Task<OperationResult<User>> AddUserAsync(UserDto userDto);
    }
}
