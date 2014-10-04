using Contacts.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using WebApiTest.Models;

namespace Contacts.Data
{
    public class ContactsEntities : DbContext
    {
        public ContactsEntities() : base("ContactsEntities")
        {

        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ContactConfiguration());
        }
    }
}