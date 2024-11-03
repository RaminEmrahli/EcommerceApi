using Ecommerce.Domain.Common;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Interfaces.Repositories
{
    public interface IReadRepository<T> where T : class, IEntityBase, new()
    {
        public Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool enableTracking = false);
        public Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null,
           Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
           Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
           bool enableTracking = false, int currentPage = 1, int pageSize = 3);
        public Task<T> GetAsync(Expression<Func<T, bool>> predicate,
           Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
           bool enableTracking = false);

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate,bool enableTracking);

        public Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);
    }
}
