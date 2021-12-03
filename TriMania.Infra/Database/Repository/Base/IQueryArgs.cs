using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TriMania.Infra.Database.Repository.Base
{
    public interface IQueryArgs<T> where T : class
    {
        List<Expression<Func<T, bool>>> Filters { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        IQueryArgs<T> Filter(Expression<Func<T, bool>> filter);
        IQueryArgs<T> AddInclude(Expression<Func<T, object>> include);
    }
}