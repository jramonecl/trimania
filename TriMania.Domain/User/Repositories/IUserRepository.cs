using System.Collections.Generic;
using System.Threading.Tasks;
using Trimania.Shared.Data;

namespace TriMania.Domain.User.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> ByLoginAsync(string login);
        Task<IEnumerable<User>> GetAllPagedAsync(int page, string term, int inPage);
    }
}