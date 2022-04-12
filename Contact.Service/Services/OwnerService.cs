using Contact.Core.Contracts;
using Contact.Core.Contracts.Repositories;
using Contact.Core.Contracts.Services;
using Contact.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Service.Services
{
    public class OwnerService : Service<OwnerModel>, IOwnerService
    {
        public OwnerService(IUnitOfWork unitOfWork, IRepository<OwnerModel> repository) : base(unitOfWork, repository)
        {
        }
      
        public OwnerModel GetOwnerByContact(int ownerId)
        {
            var model = GetById(ownerId);
            if (model is null || model.IsDeleted)
                return null;
            return model;
        }

        public void Delete(int id)
        {
            var model = GetById(id);
            if (model is null) return;
            model.IsDeleted = true;
            _unitOfWork.Commit();
        }

        public OwnerModel GetById(int Id)
        {
            return _repository.GetById(Id);
        }
    }
}
