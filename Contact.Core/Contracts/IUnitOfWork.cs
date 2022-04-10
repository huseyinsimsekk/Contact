using Contact.Core.Contracts.Repositories;
using Contact.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Core.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<ContactModel> ContactRepository { get; }
        IRepository<OwnerModel> OwnerRepository { get; }
        void Commit();
    }
}
