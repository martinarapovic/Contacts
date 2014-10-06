using Contacts.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Contacts.Data.Configurations
{
    internal class EmailAddressConfiguration : EntityTypeConfiguration<EmailAddress>
    {
        public EmailAddressConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".EmailAddresses");
            HasKey(x => x.EmailAddressId);

            Property(x => x.EmailAddressId).HasColumnName("EmailAddressId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ContactId).HasColumnName("ContactId").IsRequired();
            Property(x => x.LabelId).HasColumnName("LabelId").IsRequired();
            Property(x => x.Address).HasColumnName("Address").IsRequired().IsUnicode(false).HasMaxLength(50);

            // Foreign keys
            HasRequired(a => a.Contact).WithMany(b => b.EmailAddresses).HasForeignKey(c => c.ContactId);
            HasRequired(a => a.Label).WithMany(b => b.EmailAddresses).HasForeignKey(c => c.LabelId);
        }
    }
}