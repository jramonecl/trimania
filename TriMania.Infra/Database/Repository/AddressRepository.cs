using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriMania.Domain.User;
using TriMania.Domain.User.Repositories;
using TriMania.Infra.Database.Context;

namespace TriMania.Infra.Database.Repository
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}
