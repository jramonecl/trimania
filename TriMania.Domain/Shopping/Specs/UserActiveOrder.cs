using Trimania.Shared.Data;

namespace TriMania.Domain.Shopping.Specs
{
    public class UserActiveOrder : BaseSpecifcation<Order>
    {
        public UserActiveOrder(int userId)
        {
            AddCriteria(n => n.UserId == userId && n.CancelDate == null && n.FinishedDate == null);
            AddInclude("Items");
            AddInclude("Items.Product");
        }
    }
}