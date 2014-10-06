using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts.API.ViewModels
{
    public class PhoneNumberViewModel
    {
        public int PhoneNumberId { get; set; }
        public int ContactId { get; set; }
        public int LabelId { get; set; }
        public string Number { get; set; }
    }
}