using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WorkoutApp.Attributes
{
    /// <summary>
    /// Asserts that nickname contains only possible characters
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class NicknameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Regex.IsMatch(value?.ToString() ?? string.Empty,@"\s"))
                return new ValidationResult("Nickname can not contain whitespaces");

            var nicknamePattern = @"^\w+[a-zA-Z0-9]+\w*$";
            if (Regex.IsMatch(value?.ToString() ?? string.Empty, nicknamePattern))
                    return ValidationResult.Success;
            return new
                ValidationResult("Nickname can contain only letters, digits and underline character");
        }

        public override bool IsValid(object value)
        {
            return Regex.Match(value?.ToString() ?? string.Empty, @"\s").Success &&
                Regex.Match(value?.ToString() ?? string.Empty, @"^\w+[a-zA-Z0-9]+\w*$").Success;
        }
    }
}