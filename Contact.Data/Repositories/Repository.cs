using Contact.Core.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly MainContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(MainContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public void Add(T Entity)
        {
            _dbSet.Add(Entity);
        }

        public void Delete(T Entity)
        {
            _dbSet.Remove(Entity);
        }

        public T GetById(int Id)
        {
            return _dbSet.Find(Id);
        }

        public void Update(T Entity)
        {
            _dbSet.Update(Entity);
        }
    }
}
