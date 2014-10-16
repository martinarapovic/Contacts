using System;
using System.Collections.Generic;

namespace Contacts.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Note { get; set; }

        public virtual ICollection<EmailAddress> EmailAddresses { get; set; }
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

        public Contact()
        {
            EmailAddresses = new List<EmailAddress>();
            PhoneNumbers = new List<PhoneNumber>();
            Tags = new List<Tag>();
        }
    }
}