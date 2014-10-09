using FluentValidation;

namespace Contacts.API.ViewModels
{
    public class PhoneNumberViewModel : ViewModelBase<PhoneNumberViewModel, PhoneNumberValidator>
    {
        public int PhoneNumberId { get; set; }
        public int ContactId { get; set; }
        public int LabelId { get; set; }
        public string Number { get; set; }
    }

    public class PhoneNumberValidator : AbstractValidator<PhoneNumberViewModel>
    {
        public PhoneNumberValidator()
        {
            RuleFor(x => x.Number).NotEmpty().Length(0, 20);
        }
    }
}