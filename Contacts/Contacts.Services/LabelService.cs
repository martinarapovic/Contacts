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
    public class LabelService : ILabelService
    {
        private readonly ILabelRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public LabelService(ILabelRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Label> GetLabels()
        {
            return _repository.GetAll();
        }

        public Label AddLabel(Label model)
        {
            _repository.Add(model);
            SaveChanges();

            return model;
        }

        public Label GetLabel(int id)
        {
            return _repository.GetById(id);
        }

        public Label UpdateLabel(Label model)
        {
            _repository.Update(model);
            SaveChanges();

            return model;
        }

        public void DeleteLabel(int id)
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

    public interface ILabelService
    {
        IEnumerable<Label> GetLabels();
        Label AddLabel(Label model);
        Label GetLabel(int id);
        Label UpdateLabel(Label model);
        void DeleteLabel(int id);
    }
}
