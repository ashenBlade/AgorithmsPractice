using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WorkoutApp.Attributes
{
    public class UserNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Regex.IsMatch(value?.ToString() ?? string.Empty, @"\s"))
                return new ValidationResult("Name can not contain whitespaces");
            var namePattern = @"^[[A-Z]?[a-z]*]?$";
            if (Regex.IsMatch(value?.ToString() ?? string.Empty, namePattern))
                return ValidationResult.Success;
            return new ValidationResult("Name can contain only letters");
        }

        public override bool IsValid(object value)
        {
            return !Regex.IsMatch(value?.ToString() ?? string.Empty, @"\s") &&
                   Regex.IsMatch(value?.ToString() ?? string.Empty, @"^[[A-Z]?[a-z]*]?$");
        }
    }
}