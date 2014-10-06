using Contacts.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Contacts.Data.Configurations
{
    internal class LabelConfiguration : EntityTypeConfiguration<Label>
    {
        public LabelConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Labels");
            HasKey(x => x.LabelId);

            Property(x => x.LabelId).HasColumnName("LabelId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName("Name").IsRequired().IsUnicode(false).HasMaxLength(25);
        }
    }
}