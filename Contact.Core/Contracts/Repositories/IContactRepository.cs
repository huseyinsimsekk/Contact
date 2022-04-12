using Contact.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Core.Contracts.Repositories
{
    public interface IContactRepository : IRepository<ContactModel>
    {
        List<ContactModel> GetContactsByOwner(int ownerId);

        ContactModel SearchContact(Expression<Func<ContactModel, bool>> predicate);
    }
}
