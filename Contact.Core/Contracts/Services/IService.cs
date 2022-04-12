using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Core.Contracts.Services
{
    public interface IService<T> where T : class
    {
        void Add(T Entity);
        void Update(T Entity);
    }
}
