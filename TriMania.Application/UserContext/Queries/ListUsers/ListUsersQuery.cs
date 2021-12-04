using MediatR;
using System.Text.Json.Serialization;
using TriMania.Infra.Database.Repository.Base;

namespace TriMania.Application.UserContext.Queries.ListUsers
{
    public class ListUsersQuery : IRequest<QueryResult<UserDto>>
    {
        public int Page { get; set; }
        public string Term { get; set; }
    }
}