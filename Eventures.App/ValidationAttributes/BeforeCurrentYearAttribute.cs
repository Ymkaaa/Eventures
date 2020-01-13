using System;
using System.ComponentModel.DataAnnotations;

namespace Eventures.App.ValidationAttributes
{
    public class BeforeCurrentYearAttribute : ValidationAttribute
    {
        private readonly int afterYear;

        public BeforeCurrentYearAttribute(int afterYear)
        {
            this.afterYear = afterYear;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(value is int))
            {
                return new ValidationResult($"Invalid {validationContext.DisplayName}");
            }

            int valueAsInt = (int)value;

            if (valueAsInt > DateTime.UtcNow.Year)
            {
                return new ValidationResult($"{validationContext.DisplayName} is after {DateTime.UtcNow.Year}");
            }

            if (valueAsInt < afterYear)
            {
                return new ValidationResult($"{validationContext.DisplayName} is before {DateTime.UtcNow.Year}");
            }

            return ValidationResult.Success;
        }
    }
}
