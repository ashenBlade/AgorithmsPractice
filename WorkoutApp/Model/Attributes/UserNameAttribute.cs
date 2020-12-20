using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WorkoutApp.Controller.Attributes
{
    public class UserNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object obj, ValidationContext validationContext)
        {
            var value = obj?.ToString();
            if (value == null)
                return ValidationResult.Success;
            if (value.Length < 4 || 50 < value.Length)
                return new ValidationResult("Name must be in range of (4...50");
            if (Regex.IsMatch(value, @"\s"))
                return new ValidationResult("Name can not contain whitespaces");
            var namePattern = @"^[[A-Z]?[a-z]*]?$";
            if (!Regex.IsMatch(value, namePattern))
                return new ValidationResult("Name can contain only letters");
            return ValidationResult.Success;
        }
    }
}