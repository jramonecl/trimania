using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriMania.Domain.Shopping;

namespace TriMania.Application.ShoppingContext.AddItems
{
    public class OrderDto
    {
        public OrderDto(Order order)
        {
            this.TotalValue = order.TotalValue;
            this.CreationDate = order.CreationDate;
            this.Status = order.Status;

            this.Items = new List<OrderItemDto>();

            foreach (var item in order.Items)
            {
                this.Items.Add(new OrderItemDto(item));
            }
        }
        public decimal TotalValue { get; set; }
        public ICollection<OrderItemDto> Items { get; set; }
        public DateTime CreationDate { get; set; }
        public OrderStatus Status { get; set; }
    }
}
