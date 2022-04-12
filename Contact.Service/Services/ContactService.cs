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
    public class ContactService : Service<ContactModel>, IContactService
    {
        private readonly List<string> _allowedKeys = new List<string>() { "phone", "address", "name", "email" };
        public ContactService(IUnitOfWork unitOfWork, IRepository<ContactModel> repository) : base(unitOfWork, repository)
        {
        }

        public List<ContactModel> GetContactsByOwner(int ownerId)
        {
            return _unitOfWork.ContactRepository.GetContactsByOwner(ownerId);
        }

        public ContactModel SearchByKey(string key, string value)
        {
            if (!_allowedKeys.Contains(key)) return null;
            switch (key.ToLower())
            {
                case "phone":
                    return _unitOfWork.ContactRepository.SearchContact(m => m.PhoneNumber == value);
                case "address":
                    return _unitOfWork.ContactRepository.SearchContact(m => m.Address == value);
                case "email":
                    return _unitOfWork.ContactRepository.SearchContact(m => m.Email == value);
                case "name":
                    return _unitOfWork.ContactRepository.SearchContact(m => m.Name == value);
                default:
                    return null;
            }
        }
    }
}
