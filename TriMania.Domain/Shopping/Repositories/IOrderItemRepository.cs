using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trimania.Shared.Data;

namespace TriMania.Domain.Shopping.Repositories
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        Task<OrderItem> GetOrderItemFromOrder(int orderId, int productId);
    }
}
