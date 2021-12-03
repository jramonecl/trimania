using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TriMania.Domain;
using TriMania.Domain.User;
using TriMania.Domain.User.Repositories;
using TriMania.Domain.User.Specs;
using TriMania.Infra.Database.Context;
using Trimania.Shared.Data;
using TriMania.Domain.Shopping;
using TriMania.Domain.Shopping.Repositories;
using TriMania.Domain.Shopping.Specs;
using System.Linq;
using Trimania.Shared.Exceptions;

namespace TriMania.Infra.Database.Repository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context)
            : base(context)
        {
        }

        public async Task<bool> UserHasOrders(int userId)
        {
            var spec = new UserHasOrders(userId);
            var orders = await base.ListAsync(spec);
            return orders.Any();
        }

        public async Task<bool> UserHasActiveOrders(int userId)
        {
            var spec = new UserActiveOrder(userId);
            var orders = await base.ListAsync(spec);
            return orders.Any();
        }

        public async Task<Order> GetActiveOrder(int userId)
        {
            var spec = new UserActiveOrder(userId);
            var orders = await base.ListAsync(spec);

            if (orders.Count() > 1)
            {
                throw new BusinessRuleException("Erro ao resgatar pedido");;
            }

            return orders.FirstOrDefault();
        }
    }
}