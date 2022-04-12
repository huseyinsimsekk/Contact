using Contact.Core.Contracts.Repositories;
using Contact.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Data.Repositories
{
    public class ContactRepository : Repository<ContactModel>, IContactRepository
    {
        public ContactRepository(MainContext context) : base(context)
        {
        }

        public List<ContactModel> GetContactsByOwner(int ownerId)
        {
            return _context.Contacts.Where(m => m.OwnerId == ownerId && !m.IsDeleted).ToList();
        }

        public ContactModel SearchContact(Expression<Func<ContactModel, bool>> predicate)
        {
            return _context.Contacts.FirstOrDefault(predicate);
        }
    }
}
