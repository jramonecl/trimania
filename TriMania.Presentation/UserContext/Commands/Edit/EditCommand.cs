using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MediatR;

namespace TriMania.Application.UserContext.Commands.Edit
{
    public class EditCommand : IRequest<int>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public EditAddressCommand Address { get; set; }
    }
}
