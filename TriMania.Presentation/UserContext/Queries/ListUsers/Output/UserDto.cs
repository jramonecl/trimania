using System;

namespace TriMania.Application.UserContext.Queries.ListUsers
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime CreationDate { get; set; }
        public AddressDto Address { get; set; }
    }
}