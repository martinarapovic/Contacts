using Contacts.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Contacts.Data.Configurations
{
    internal class ContactConfiguration : EntityTypeConfiguration<Contact>
    {
        public ContactConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Contacts");
            HasKey(x => x.ContactId);

            Property(x => x.ContactId).HasColumnName("ContactId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.FirstName).HasColumnName("FirstName").IsRequired().IsUnicode(false).HasMaxLength(50);
            Property(x => x.LastName).HasColumnName("LastName").IsRequired().IsUnicode(false).HasMaxLength(50);
            Property(x => x.Address).HasColumnName("Address").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.City).HasColumnName("City").IsRequired().IsUnicode(false).HasMaxLength(50);
            Property(x => x.Note).HasColumnName("Note").IsOptional().IsUnicode(false).HasMaxLength(255);
        }
    }
}