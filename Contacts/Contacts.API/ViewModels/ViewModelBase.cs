using Contacts.Common.Extensions;
using FluentValidation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace Contacts.API.ViewModels
{
    public abstract class ViewModelBase<TViewModel, TValidator> : IValidatableObject
        where TViewModel : class
        where TValidator : AbstractValidator<TViewModel>, new()
    {
        private readonly IValidator<TViewModel> _validator;

        protected ViewModelBase()
        {
            _validator = new TValidator();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return _validator.Validate<TViewModel>(validationContext.ObjectInstance as TViewModel).ToValidationResult();
        }
    }
}