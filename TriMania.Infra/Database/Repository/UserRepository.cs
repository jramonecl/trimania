using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TriMania.Domain;
using TriMania.Domain.User;
using TriMania.Domain.User.Repositories;
using TriMania.Domain.User.Specs;
using TriMania.Infra.Database.Context;
using Trimania.Shared.Data;
using TriMania.Domain.Shopping.Specs;

namespace TriMania.Infra.Database.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(AppDbContext context)
            : base(context)
        {
        }

        public async Task<User> ByLoginAsync(string login)
        {
            var spec = new GetByLogin(login);
            return await base.SingleAsync(spec);
        }

        public async Task<IEnumerable<User>> GetAllPagedAsync(int page, string term, int inPage)
        {
            var spec = new GetByTerm(term);
            return await ListPagedAsync(spec, page, inPage);
        }
    }
}