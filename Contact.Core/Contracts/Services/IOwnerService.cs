using Contact.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Core.Contracts.Services
{
    public interface IOwnerService : IService<OwnerModel>
    {
        OwnerModel GetOwnerByContact(int ownerId);
        void Delete(int id);
        OwnerModel GetById(int Id);
    }
}
