using FluentValidation.Results;

namespace Application.Common.Extensions
{
    public static class ValidationFailureExtensions
    {
        public static IDictionary<string, string[]> ToDictionary(this IEnumerable<ValidationFailure> validationFailures)
        {
            return validationFailures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }
    }
}
