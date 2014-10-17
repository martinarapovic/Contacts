using System.Linq;
using Contacts.Data.Infrastructure;
using Contacts.Data.Repositories;
using Contacts.Models;
using System.Collections.Generic;

namespace Contacts.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ContactService(IContactRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Contact> GetContacts()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Contact> GetContacts(string condition)
        {
            return _repository.GetMany(x =>
                                       x.FirstName.Contains(condition) ||
                                       x.LastName.Contains(condition) ||
                                       x.Tags.Any(t => t.Name.Contains(condition)));
        }

        public Contact AddContact(Contact model)
        {
            _repository.Add(model);
            SaveChanges();

            return model;
        }

        public Contact GetContact(int id)
        {
            return _repository.GetByIdWithoutTracking(id);
        }

        public Contact UpdateContact(Contact model)
        {
            _repository.Update(model);
            SaveChanges();

            return model;
        }

        public void DeleteContact(int id)
        {
            var contact = _repository.GetById(id);
            _repository.Delete(contact);
            SaveChanges();
        }

        private void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }
    }

    public interface IContactService
    {
        IEnumerable<Contact> GetContacts();
        IEnumerable<Contact> GetContacts(string condition);
        Contact AddContact(Contact model);
        Contact GetContact(int id);
        Contact UpdateContact(Contact model);
        void DeleteContact(int id);
    }
}