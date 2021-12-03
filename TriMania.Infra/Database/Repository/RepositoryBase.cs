using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TriMania.Domain.Base;
using TriMania.Infra.Database.Context;
using TriMania.Infra.Database.Repository.Base;
using Trimania.Shared.Data;
using System;

namespace TriMania.Infra.Database.Repository
{
    public class RepositoryBase<T> : IRepository<T> where T : Entity
    {
        private readonly AppDbContext _context;
        private readonly IQueryable<T> _set;
        public RepositoryBase(AppDbContext context)
        {
            _context = context;
            _set = context.Set<T>().AsNoTracking();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _set.FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _set.ToListAsync();
        }

        public async Task<T> SingleAsync(ISpecification<T> spec = null)
        {
            return await GetQuery(_set.AsQueryable(), spec).FirstOrDefaultAsync();
        }

        public async Task<IList<T>> ListAsync(ISpecification<T> spec = null)
        {
            return await GetQuery(_set.AsQueryable(), spec).ToListAsync();
        }

        public async Task<IList<T>> ListPagedAsync(ISpecification<T> spec, int pageNumber, int itemsPerPage)
        {
            var query = GetQuery(_set.AsQueryable(), spec);

            var items = query.Skip((pageNumber - 1) * itemsPerPage).Take(itemsPerPage);

            return await items.ToListAsync();
        }

        public async Task InsertAsync(T entity)
        {
            _ = await _context.Set<T>().AddAsync(entity);
        }

        public async Task InsertAsync(IEnumerable<T> entities)
        {
            foreach (var item in entities)
            {
                await this.InsertAsync(item);
            }
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<int> CountAsync()
        {
            var query = _set;
            return await query.CountAsync();
        }

        public async Task<IList<T>> ListAsync(IQueryArgs<T> queryArgs)
        {
            var query = _set;

            return await query.ToListAsync();
        }

        public IQueryable<T> GetQuery(IQueryable<T> query, ISpecification<T> spec)
        {
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }
            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }
            if (spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }
            if (spec.Includes.Any())
            {
                query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            }
            if (spec.IncludeStrings.Any())
            {
                query = spec.IncludeStrings.Aggregate(query,
                               (current, include) => current.Include(include));
            }

            return query;
        }
    }
}