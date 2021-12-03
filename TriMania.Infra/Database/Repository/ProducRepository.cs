using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TriMania.Domain;
using TriMania.Domain.User;
using TriMania.Domain.User.Repositories;
using TriMania.Domain.User.Specs;
using TriMania.Infra.Database.Context;
using Trimania.Shared.Data;
using TriMania.Domain.Shopping.Repositories;
using TriMania.Domain.Shopping;

namespace TriMania.Infra.Database.Repository
{
    public class ProducRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProducRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}