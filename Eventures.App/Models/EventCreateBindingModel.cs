using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eventures.App.Models
{
    public class EventCreateBindingModel : IValidatableObject
    {
        private const string InvalidNameLengthMessage = "The {0} length should be bigger than {1}";
        private const string InvalidTotalTicketsCountMessage = "The {0} should be between {1} and {2}";

        [Required]
        [MinLength(10, ErrorMessage = InvalidNameLengthMessage)]
        public string Name { get; set; }

        [Required]
        public string Place { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = InvalidTotalTicketsCountMessage)]
        [Display(Name = "Total Tickets")]
        public int TotalTickets { get; set; }

        [Required]
        [Display(Name = "Price Per Ticket")]
        public decimal PricePerTicket { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Name == "Lili Ivanova" && this.Place == "Ruse")
            {
                yield return new ValidationResult("Forbidden.");
            }
        }
    }
}
