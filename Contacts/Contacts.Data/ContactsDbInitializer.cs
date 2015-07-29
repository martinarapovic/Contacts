using System;
using System.Collections.Generic;
using System.Data.Entity;
using Contacts.Models;

namespace Contacts.Data
{
    public class ContactsDbInitializer : DropCreateDatabaseIfModelChanges<ContactsEntities>
    {
        protected override void Seed(ContactsEntities context)
        {
            // Add some data into db initially...
            context.Labels.Add(new Label { Name = "Home"});
            context.Labels.Add(new Label { Name = "Work" });
            context.Labels.Add(new Label { Name = "Private" });
            
            context.SaveChanges();
        }
    }
}
