namespace chattech_auth.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(string userId, string username);
    }
}
