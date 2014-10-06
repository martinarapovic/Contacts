using Contacts.Data.Configurations;
using Contacts.Models;
using System.Data.Entity;

namespace Contacts.Data
{
    public class ContactsEntities : DbContext
    {
        public IDbSet<Contact> Contacts { get; set; }
        public IDbSet<EmailAddress> EmailAddresses { get; set; }
        public IDbSet<Label> Labels { get; set; }
        public IDbSet<PhoneNumber> PhoneNumbers { get; set; }
        public IDbSet<Tag> Tags { get; set; }

        public ContactsEntities()
            : base("ContactsEntities")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ContactConfiguration());
            modelBuilder.Configurations.Add(new EmailAddressConfiguration());
            modelBuilder.Configurations.Add(new LabelConfiguration());
            modelBuilder.Configurations.Add(new PhoneNumberConfiguration());
            modelBuilder.Configurations.Add(new TagConfiguration());
        }
    }
}