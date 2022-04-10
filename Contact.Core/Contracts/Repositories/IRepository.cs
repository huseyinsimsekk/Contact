using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Core.Contracts.Repositories
{
    public interface IRepository<T> where T : class
    {
        T GetById(int Id);
        T SingleOrDefault(Expression<Func<T, bool>> predicate);
        void Add(T Entity);
        void Delete(T Entity);
        void Update(T Entity);
    }
}
