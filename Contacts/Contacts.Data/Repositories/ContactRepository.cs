using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contacts.Data.Infrastructure;
using Contacts.Models;
using RefactorThis.GraphDiff;

namespace Contacts.Data.Repositories
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
            
        }

        public override Contact GetById(int id)
        {
            return base.DataContext.Contacts.AsNoTracking()
                       .Include(x => x.EmailAddresses)
                       .Include(x => x.EmailAddresses.Select(y => y.Label))
                       .Include(x => x.PhoneNumbers)
                       .Include(x => x.PhoneNumbers.Select(y=> y.Label))
                       .Include(x => x.Tags)
                       .First(x => x.ContactId == id);
        }

        public override void Update(Contact entity)
        {
            base.DataContext.Entry(entity).State = EntityState.Detached;
            base.DataContext.UpdateGraph(entity,
                                         map =>
                                         map.OwnedCollection(x => x.EmailAddresses)
                                            .OwnedCollection(x => x.PhoneNumbers)
                                            .OwnedCollection(x => x.Tags));
        }
    }

    public interface IContactRepository : IRepository<Contact>
    {

    }
}