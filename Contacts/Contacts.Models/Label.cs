using System.Collections.Generic;

namespace Contacts.Models
{
    public class Label
    {
        public int LabelId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<EmailAddress> EmailAddresses { get; set; }
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }

        public Label()
        {
            EmailAddresses = new List<EmailAddress>();
            PhoneNumbers = new List<PhoneNumber>();
        }
    }
}