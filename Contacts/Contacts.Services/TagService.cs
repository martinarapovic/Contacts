using Contacts.Data.Infrastructure;
using Contacts.Data.Repositories;
using Contacts.Models;
using System.Collections.Generic;

namespace Contacts.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public TagService(ITagRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Tag> GetTags()
        {
            return _repository.GetAll();
        }

        public Tag AddTag(Tag model)
        {
            _repository.Add(model);
            SaveChanges();

            return model;
        }

        public Tag GetTag(int id)
        {
            return _repository.GetById(id);
        }

        public Tag UpdateTag(Tag model)
        {
            _repository.Update(model);
            SaveChanges();

            return model;
        }

        public void DeleteTag(int id)
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

    public interface ITagService
    {
        IEnumerable<Tag> GetTags();
        Tag AddTag(Tag model);
        Tag GetTag(int id);
        Tag UpdateTag(Tag model);
        void DeleteTag(int id);
    }
}
