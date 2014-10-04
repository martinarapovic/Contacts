using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contacts.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Note { get; set; }

        public Contact()
        {
        
        }
    }
}
