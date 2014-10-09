using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contacts.Data.Infrastructure;
using Contacts.Data.Repositories;
using Contacts.Models;

namespace Contacts.Services
{
    public class PhoneNumberService : IPhoneNumberService
    {
        private readonly IPhoneNumberRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public PhoneNumberService(IPhoneNumberRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<PhoneNumber> GetPhoneNumbers()
        {
            return _repository.GetAll();
        }

        public PhoneNumber AddPhoneNumber(PhoneNumber model)
        {
            _repository.Add(model);
            SaveChanges();

            return model;
        }

        public PhoneNumber GetPhoneNumber(int id)
        {
            return _repository.GetById(id);
        }

        public PhoneNumber UpdatePhoneNumber(PhoneNumber model)
        {
            _repository.Update(model);
            SaveChanges();

            return model;
        }

        public void DeletePhoneNumber(int id)
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

    public interface IPhoneNumberService
    {
        IEnumerable<PhoneNumber> GetPhoneNumbers();
        PhoneNumber AddPhoneNumber(PhoneNumber model);
        PhoneNumber GetPhoneNumber(int id);
        PhoneNumber UpdatePhoneNumber(PhoneNumber model);
        void DeletePhoneNumber(int id);
    }
}
