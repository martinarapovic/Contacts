using Contacts.Data.Infrastructure;
using Contacts.Models;

namespace Contacts.Data.Repositories
{
    public class EmailAddressesRepository : RepositoryBase<EmailAddress>, IEmailAddressRepository
    {
        public EmailAddressesRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }
    }

    public interface IEmailAddressRepository : IRepository<EmailAddress>
    {

    }
}