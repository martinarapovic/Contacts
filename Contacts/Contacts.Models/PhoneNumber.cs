
namespace Contacts.Models
{
    public class PhoneNumber
    {
        public int PhoneNumberId { get; set; }
        public int ContactId { get; set; }
        public int LabelId { get; set; }
        public string Number { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Label Label { get; set; }
    }
}