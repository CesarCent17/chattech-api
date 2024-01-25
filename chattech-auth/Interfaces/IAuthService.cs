using chattech_auth.Models.Dto;
using chattech_auth.Models.Entities;

namespace chattech_auth.Interface 
{
    public interface IAuthService
    {
        Task<OperationResult<string>> Login(AuthRequest authRequest);
    }
}