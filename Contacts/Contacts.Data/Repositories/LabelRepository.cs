using Contacts.Data.Infrastructure;
using Contacts.Models;

namespace Contacts.Data.Repositories
{
    public class LabelRepository : RepositoryBase<Label>, ILabelRepository
    {
        public LabelRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }
    }

    public interface ILabelRepository : IRepository<Label>
    {

    }
}