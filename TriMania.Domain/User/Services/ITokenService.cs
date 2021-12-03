namespace TriMania.Domain.User.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}