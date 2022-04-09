using Contact.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Core.Contracts.Services
{
    public interface IContactService : IService<ContactModel>
    {
        ContactModel SearchByKey(string key, string value);
    }
}
