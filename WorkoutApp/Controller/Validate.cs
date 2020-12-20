using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WorkoutApp.Controller.Attributes;

namespace WorkoutApp.Controller
{
    public static class Validate
    {
        public static List<ValidationResult> UserName(string name)
        {
            var validationContext = new ValidationContext(name);
            var results = new List<ValidationResult>();
            Validator.TryValidateValue(name, validationContext, results, new []{ new UserNameAttribute() });
            return results;
        }
    }
}