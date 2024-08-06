namespace EMS.Services
{
    public interface ITokenService
    {
        string GenerateToken(string userId);
    }
}