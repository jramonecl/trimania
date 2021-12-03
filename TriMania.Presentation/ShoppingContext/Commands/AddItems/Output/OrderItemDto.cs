using TriMania.Domain.Shopping;

namespace TriMania.Application.ShoppingContext.AddItems
{
    public class OrderItemDto
    {
        private OrderItem item;

        public OrderItemDto(OrderItem item)
        {
            this.Name = item.Product.Name;
            this.Price = item.Price;
            this.Quantity = item.Quantity;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}