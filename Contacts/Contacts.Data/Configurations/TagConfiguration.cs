using Contacts.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Contacts.Data.Configurations
{
    internal class TagConfiguration : EntityTypeConfiguration<Tag>
    {
        public TagConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Tags");
            HasKey(x => x.TagId);

            Property(x => x.TagId).HasColumnName("TagId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ContactId).HasColumnName("ContactId").IsRequired();
            Property(x => x.Name).HasColumnName("Name").IsRequired().IsUnicode(false).HasMaxLength(50);

            // Foreign keys
            HasRequired(a => a.Contact).WithMany(b => b.Tags).HasForeignKey(c => c.ContactId);
        }
    }
}