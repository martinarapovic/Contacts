using FluentValidation;

namespace Contacts.API.ViewModels
{
    public class LabelViewModel : ViewModelBase<LabelViewModel, LabelValidator>
    {
        public int LabelId { get; set; }
        public string Name { get; set; }
    }

    public class LabelValidator : AbstractValidator<LabelViewModel>
    {
        public LabelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(0, 25);
        }
    }
}