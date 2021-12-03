using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trimania.Shared.Data;

namespace TriMania.Domain.Shopping.Specs
{
    public class GetOrderItemFromOrder : BaseSpecifcation<OrderItem>
    {
        public GetOrderItemFromOrder(int orderId, int productId)
        {
            AddCriteria(n => n.OrderId == orderId && n.ProductId == productId);
        }
    }
}
