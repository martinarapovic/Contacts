using FluentValidation;

namespace Contacts.API.ViewModels
{
    public class TagViewModel : ViewModelBase<TagViewModel, TagValidator>
    {
        public int TagId { get; set; }
        public int ContactId { get; set; }
        public string Name { get; set; }
    }

    public class TagValidator : AbstractValidator<TagViewModel>
    {
        public TagValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(0, 50);
        }
    }
}