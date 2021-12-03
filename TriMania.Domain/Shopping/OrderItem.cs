using TriMania.Domain.Base;

namespace TriMania.Domain.Shopping
{
    public class OrderItem : Entity
    {
        public OrderItem()
        {

        }
        private OrderItem(int ProductId, int OrderId, decimal Price, int Quantity)
        {
            this.ProductId = ProductId;
            this.OrderId = OrderId;
            this.Price = Price;
            this.Quantity = Quantity;
        }

        public int OrderId { get; private set; }
        public int ProductId { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public Product Product { get; private set; }

        public void SetQuantity(int quantity)
        {
            Quantity = quantity;
        }
        public void SetPrice(decimal price)
        {
            Price = price;
        }
        public static OrderItem CreateNew(int ProductId, int OrderId, decimal Price, int Quantity)
        {
            return new(ProductId, OrderId, Price, Quantity);
        }
    }
}