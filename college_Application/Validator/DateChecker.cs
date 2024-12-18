using System.ComponentModel.DataAnnotations;

namespace college_Application.Validator
{
    public class DateChecker : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value,ValidationContext validationContext)
        {
            var date = (DateTime?)value;
            if (date<DateTime.Now)
            {
                return new ValidationResult("The date must be greater than today");
            }
            return ValidationResult.Success;
        }
    }
}
