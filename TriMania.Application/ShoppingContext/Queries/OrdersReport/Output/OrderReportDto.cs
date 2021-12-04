using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TriMania.Domain.Shopping;

namespace TriMania.Application.ShoppingContext.Queries.OrdersReport.Output
{
    public class OrderReportDto
    {
        public OrderReportDto()
        {
            Orders = new List<OrdersDto>();
        }
        public int FinishedOrdersAmount { get; set; }
        public int CancelledOrdersAmount { get; set; }
        public int OrdersTotalValue { get; set; }
        public List<OrdersDto> Orders { get; set; }
    }

    public class OrdersDto
    {
        public OrdersDto()
        {
            Items = new List<ItemsDto>();
        }
        public string UserName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? CancelDate { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime? FinishedDate { get; set; }
        public List<ItemsDto> Items { get; set; }
        [JsonIgnore]
        public int Id { get; set; }
    }

    public class ItemsDto
    {
        public string Product { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
