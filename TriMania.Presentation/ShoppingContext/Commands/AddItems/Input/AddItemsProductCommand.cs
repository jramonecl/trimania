using System;
using System.Text.Json.Serialization;

namespace TriMania.Application.ShoppingContext.AddItems
{
    public class AddItemsProductCommand 
    {
        [JsonIgnore]
        public Action ActionParsed => (Action)Enum.Parse(typeof(Action), Action);
        public string Action { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public void AdjustQuantityBy(int quantity)
        {
            Quantity += quantity;
        }
    }
}