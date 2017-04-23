using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Finder.Data.Repository
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IJobRepository<T> where T : class
    {
        IQueryable<T> All();

        T Find(object id);

        IQueryable<T> SearchFor(Expression<Func<T, bool>> conditions);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Detach(T entity);
    }
}
