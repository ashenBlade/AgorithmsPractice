using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WorkoutApp.Attributes
{
    public class FoodNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var foodNamePattern = "^[A-Za-z][A-Za-z ]*[A-Za-z]$";
            if (Regex.IsMatch(value?.ToString() ?? string.Empty, foodNamePattern))
                return ValidationResult.Success;
            return new ValidationResult("Food name can contain only letters and whitespaces");
        }
    }
}