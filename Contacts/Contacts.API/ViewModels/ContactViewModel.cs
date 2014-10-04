using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts.API.ViewModels
{
    public class ContactViewModel
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}