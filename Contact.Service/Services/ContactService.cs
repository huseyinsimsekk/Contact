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

        public void Delete(int id)
        {
            var model = _repository.GetById(id);
            if (model is null) return;
            model.IsDeleted = true;
            _unitOfWork.Commit();
        }

        public List<ContactModel> GetContactsByOwner(int ownerId)
        {
            return _unitOfWork.ContactRepository.GetContactsByOwner(ownerId);
        }

        public ContactModel SearchByKey(int ownerId, string key, string value)
        {
            if (!_allowedKeys.Contains(key)) return null;
            switch (key.ToLower())
            {
                case "phone":
                    return _unitOfWork.ContactRepository.SearchContact(m => m.PhoneNumber == value && m.OwnerId == ownerId);
                case "address":
                    return _unitOfWork.ContactRepository.SearchContact(m => m.Address == value && m.OwnerId == ownerId);
                case "email":
                    return _unitOfWork.ContactRepository.SearchContact(m => m.Email == value && m.OwnerId == ownerId);
                case "name":
                    return _unitOfWork.ContactRepository.SearchContact(m => m.Name == value && m.OwnerId == ownerId);
                default:
                    return null;
            }
        }

        public void Add(ContactModel model)
        {
            if (SearchByKey(model.OwnerId, "phone", model.PhoneNumber) != null || SearchByKey(model.OwnerId, "name", model.Name) != null)
                throw new Exception("Cannot Added Contact. There is record with this phone number or name!");
            base.Add(model);
        }
    }
}
