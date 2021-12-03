namespace TriMania.Domain.User.Services
{
    public interface IHashService
    {
        string ComputeHash(string message);
    }
}