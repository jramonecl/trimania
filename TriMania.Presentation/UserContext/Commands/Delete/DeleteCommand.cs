using System.Text.Json.Serialization;
using MediatR;

namespace TriMania.Application.UserContext.Commands.Delete
{
    public class DeleteCommand : IRequest
    {
        [JsonIgnore]
        public int Id { get; set; }
    }
}