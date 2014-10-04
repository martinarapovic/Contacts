using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contacts.Data.Infrastructure;
using Contacts.Models;

namespace Contacts.Data.Repositories
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }
    }

    public interface IContactRepository : IRepository<Contact>
    {

    }
}