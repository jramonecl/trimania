using System.Collections.Generic;
using System.Threading.Tasks;

namespace Trimania.Shared.Data
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> SingleAsync(ISpecification<T> spec = null);
        Task<IList<T>> ListAsync(ISpecification<T> spec = null);
        Task<IList<T>> ListPagedAsync(ISpecification<T> spec, int pageNumber, int itemsPerPage);
        Task InsertAsync(T entity);
        Task InsertAsync(IEnumerable<T> entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<int> CountAsync();
    }
}