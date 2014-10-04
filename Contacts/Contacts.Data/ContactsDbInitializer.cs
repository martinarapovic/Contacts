using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Contacts.Data
{
    public class ContactsDbInitializer : DropCreateDatabaseIfModelChanges<ContactsEntities>
    {
        protected override void Seed(ContactsEntities context)
        {
            // Add some data into db initially...
        }
    }
}
