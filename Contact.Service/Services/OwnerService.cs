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
    }
}
