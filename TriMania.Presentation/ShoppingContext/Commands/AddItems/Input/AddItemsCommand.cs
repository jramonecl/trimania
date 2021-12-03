using System.Collections.Generic;
using System.Text.Json.Serialization;
using MediatR;

namespace TriMania.Application.ShoppingContext.AddItems
{
    public class AddItemsCommand : IRequest<OrderDto>
    {
        [JsonIgnore]
        public int UserId { get; set; }
        public List<AddItemsProductCommand> Items{ get; set; }

    }
}