using Contacts.Data.Infrastructure;
using Contacts.Data.Repositories;
using Contacts.Models;
using System.Collections.Generic;

namespace Contacts.Services
{
    public class EmailAddressService : IEmailAddressService
    {
        private readonly IEmailAddressRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public EmailAddressService(IEmailAddressRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<EmailAddress> GetEmailAddresses()
        {
            return _repository.GetAll();
        }

        public EmailAddress AddEmailAddress(EmailAddress model)
        {
            _repository.Add(model);
            SaveChanges();

            return model;
        }

        public EmailAddress GetEmailAddress(int id)
        {
            return _repository.GetById(id);
        }

        public EmailAddress UpdateEmailAddress(EmailAddress model)
        {
            _repository.Update(model);
            SaveChanges();

            return model;
        }

        public void DeleteEmailAddress(int id)
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

    public interface IEmailAddressService
    {
        IEnumerable<EmailAddress> GetEmailAddresses();
        EmailAddress AddEmailAddress(EmailAddress model);
        EmailAddress GetEmailAddress(int id);
        EmailAddress UpdateEmailAddress(EmailAddress model);
        void DeleteEmailAddress(int id);
    }
}
