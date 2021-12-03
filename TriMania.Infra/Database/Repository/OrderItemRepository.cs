using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriMania.Domain.Shopping;
using TriMania.Domain.Shopping.Repositories;
using TriMania.Domain.Shopping.Specs;
using TriMania.Infra.Database.Context;

namespace TriMania.Infra.Database.Repository
{
    public class OrderItemRepository : RepositoryBase<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<OrderItem> GetOrderItemFromOrder(int orderId, int productId)
        {
            var spec = new GetOrderItemFromOrder(orderId, productId);
            return await base.SingleAsync(spec);
        }
    }
}
