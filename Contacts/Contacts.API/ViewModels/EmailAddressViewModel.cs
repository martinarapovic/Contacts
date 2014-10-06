using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts.API.ViewModels
{
    public class EmailAddressViewModel
    {
        public int EmailAddressId { get; set; }
        public int ContactId { get; set; }
        public int LabelId { get; set; }
        public string Address { get; set; }
    }
}