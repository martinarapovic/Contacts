using FluentValidation;

namespace Contacts.API.ViewModels
{
    public class EmailAddressViewModel : ViewModelBase<EmailAddressViewModel, EmailAddressValidator>
    {
        public int EmailAddressId { get; set; }
        public string Address { get; set; }
        public int ContactId { get; set; }
        public int LabelId { get; set; }
        public LabelViewModel Label { get; set; }
    }

    public class EmailAddressValidator : AbstractValidator<EmailAddressViewModel>
    {
        public EmailAddressValidator()
        {
            RuleFor(x => x.Address).EmailAddress();
        }
    }
}