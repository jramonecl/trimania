using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trimania.Shared.Data;

namespace TriMania.Domain.Shopping.Specs
{
    public class UserHasOrders : BaseSpecifcation<Order>
    {
        public UserHasOrders(int userId)
        {
            AddCriteria(n => n.UserId == userId);
        }
    }
}
