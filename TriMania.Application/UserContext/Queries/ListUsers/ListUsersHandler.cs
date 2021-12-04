using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TriMania.Domain.User;
using TriMania.Domain.User.Repositories;
using TriMania.Infra.Database.Repository.Base;

namespace TriMania.Application.UserContext.Queries.ListUsers
{
    public class ListUsersHandler : IRequestHandler<ListUsersQuery, QueryResult<UserDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        const int InPage = 10;

        public ListUsersHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<QueryResult<UserDto>> Handle(ListUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetAllPagedAsync(request.Page, request.Term, InPage);

            var count = await _userRepository.CountAsync();

            var mapped =
                new QueryResult<UserDto>(_mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(result),
                    new PaginationInfo(request.Page, count, InPage > count ? count : InPage));

            return mapped;
        }
    }
}