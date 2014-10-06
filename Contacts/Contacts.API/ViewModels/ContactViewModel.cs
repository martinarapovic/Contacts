using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Contacts.Models;

namespace Contacts.API.ViewModels
{
    public class ContactViewModel
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Note { get; set; }

        public IEnumerable<EmailAddressViewModel> EmailAddresses { get; set; }
        public IEnumerable<PhoneNumberViewModel> PhoneNumbers { get; set; }
        public IEnumerable<TagViewModel> Tags { get; set; }
    }
}