using System.Threading.Tasks;
using Trimania.Shared.Data;

namespace TriMania.Domain.Shopping.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<bool> UserHasOrders(int userId);
        Task<bool> UserHasActiveOrders(int userId);
        Task<Order> GetActiveOrder(int userId);
    }
}