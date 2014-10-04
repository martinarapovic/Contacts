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

        public Contact AddContact(Contact contact)
        {
            _repository.Add(contact);
            SaveChanges();

            return contact;
        }

        public Contact GetContactById(int id)
        {
            return _repository.GetById(id);
        }

        public Contact UpdateContact(Contact contact)
        {
            _repository.Update(contact);
            SaveChanges();

            return contact;
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
        Contact AddContact(Contact contact);
        Contact GetContactById(int id);
        Contact UpdateContact(Contact contact);
        void DeleteContact(int id);
    }
}