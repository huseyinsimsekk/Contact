using Contact.Core.Contracts;
using Contact.Core.Contracts.Repositories;
using Contact.Core.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IRepository<T> _repository;
        public Service(IUnitOfWork unitOfWork, IRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        public void Add(T Entity)
        {
            _repository.Add(Entity);
            _unitOfWork.Commit();
        }
    
        public void Update(T Entity)
        {
            _repository.Update(Entity);
            _unitOfWork.Commit();
        }
    }
}
