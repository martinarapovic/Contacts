using Contacts.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Contacts.Data.Configurations
{
    internal class PhoneNumberConfiguration : EntityTypeConfiguration<PhoneNumber>
    {
        public PhoneNumberConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".PhoneNumbers");
            HasKey(x => x.PhoneNumberId);

            Property(x => x.PhoneNumberId).HasColumnName("PhoneNumberId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ContactId).HasColumnName("ContactId").IsRequired();
            Property(x => x.LabelId).HasColumnName("LabelId").IsRequired();
            Property(x => x.Number).HasColumnName("Number").IsRequired().IsUnicode(false).HasMaxLength(20);

            // Foreign keys
            HasRequired(a => a.Contact).WithMany(b => b.PhoneNumbers).HasForeignKey(c => c.ContactId);
            HasRequired(a => a.Label).WithMany(b => b.PhoneNumbers).HasForeignKey(c => c.LabelId);
        }
    }
}