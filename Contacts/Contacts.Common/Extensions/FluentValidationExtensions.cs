using System.Collections.Generic;
using System.Linq;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace Contacts.Common.Extensions
{
    public static class FluentValidationExtensions
    {
        /// <summary>
        /// Converts the Fluent Validation result to the type the both mvc and webapi expect
        /// </summary>
        /// <param name="validationResult">The validation result.</param>
        /// <returns></returns>
        public static IEnumerable<ValidationResult> ToValidationResult(
            this FluentValidation.Results.ValidationResult validationResult)
        {
            return validationResult.Errors.Select(
                item => new ValidationResult(item.ErrorMessage, new List<string> {item.PropertyName}));
        }
    }
}