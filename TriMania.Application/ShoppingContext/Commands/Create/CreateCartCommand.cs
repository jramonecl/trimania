using System.Text.Json.Serialization;
using MediatR;

namespace TriMania.Application.ShoppingContext.Create
{
    public class CreateCartCommand : IRequest<int>
    {
        [JsonIgnore]
        public int UserId { get; set; }
    }
}