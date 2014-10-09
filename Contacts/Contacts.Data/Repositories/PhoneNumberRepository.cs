using Contacts.Data.Infrastructure;
using Contacts.Models;

namespace Contacts.Data.Repositories
{
    public class PhoneNumberRepository : RepositoryBase<PhoneNumber>, IPhoneNumberRepository
    {
        public PhoneNumberRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }
    }

    public interface IPhoneNumberRepository : IRepository<PhoneNumber>
    {
         
    }
}
