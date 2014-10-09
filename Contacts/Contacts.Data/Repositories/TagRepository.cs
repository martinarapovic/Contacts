using Contacts.Data.Infrastructure;
using Contacts.Models;

namespace Contacts.Data.Repositories
{
    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }
    }

    public interface ITagRepository : IRepository<Tag>
    {

    }
}