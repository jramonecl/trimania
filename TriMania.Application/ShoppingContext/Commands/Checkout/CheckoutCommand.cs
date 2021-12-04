using MediatR;
using TriMania.Domain.Shopping;

namespace TriMania.Application.ShoppingContext.Checkout
{
    public class CheckoutCommand : IRequest
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
    }
}