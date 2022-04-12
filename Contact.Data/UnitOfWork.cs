using Contact.Core.Contracts;
using Contact.Core.Contracts.Repositories;
using Contact.Core.Models;
using Contact.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MainContext _mainContext;
        private ContactRepository _contactRepository;
        private Repository<OwnerModel> _ownerRepository;
        public IContactRepository ContactRepository => _contactRepository = _contactRepository ?? new ContactRepository(_mainContext);

        public IRepository<OwnerModel> OwnerRepository => _ownerRepository = _ownerRepository ?? new Repository<OwnerModel>(_mainContext);
        public UnitOfWork(MainContext mainContext)
        {
           _mainContext= mainContext;
        }
        public void Commit()
        {
            _mainContext.SaveChanges();
        }
    }
}
