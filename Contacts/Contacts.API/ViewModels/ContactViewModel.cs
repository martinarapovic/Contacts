using FluentValidation;
using System;
using System.Collections.Generic;

namespace Contacts.API.ViewModels
{
    public class ContactViewModel : ViewModelBase<ContactViewModel, ContactValidator>
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

    public class ContactValidator : AbstractValidator<ContactViewModel>
    {
        public ContactValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().Length(0, 50);
            RuleFor(x => x.LastName).NotEmpty().Length(0, 50);
            RuleFor(x => x.DateOfBirth).NotNull();
            RuleFor(x => x.Address).NotEmpty().Length(0, 100);
            RuleFor(x => x.City).NotEmpty().Length(0, 50);
            RuleFor(x => x.Note).Length(0, 255);
        }
    }
}