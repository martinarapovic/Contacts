
namespace Contacts.Models
{
    public class EmailAddress
    {
        public int EmailAddressId { get; set; }
        public int ContactId { get; set; }
        public int LabelId { get; set; }
        public string Address { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Label Label { get; set; }
    }

}