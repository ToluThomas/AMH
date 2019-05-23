using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AMHaulage.Models
{
    public class Appointment : IValidatableObject
    {
        // Appointment ID to uniquely identify each appointment in database
        public int Id { get; set; }

        // Appointment start date with required validation and custom error message
        [Required(ErrorMessage = "Please enter start date")]
        // Change how start date name heading is shown in HTML
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        // Appointment end date with required validation and custom error message
        [Required(ErrorMessage = "Please enter end date")]

        // Change how end date name heading is shown in HTML
        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }

        // Appointment summary with required validation, string length restriction of 255 characters
        // and custom error messages
        [Required(ErrorMessage = "Please enter a summary of the appointment")]
        [StringLength(255, ErrorMessage = "Summary cannot be greater than 255 characters.")]
        public string Summary { get; set; }

        // Appointment location with required validation, string length restriction of 255 characters
        // and custom error messages
        [Required(ErrorMessage = "Please enter a location")]
        [StringLength(255, ErrorMessage = "Summary cannot be greater than 255 characters.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Please enter driver's name")]
        [StringLength(100, ErrorMessage = "Driver name cannot be greater than 100 characters.")]
        public string Driver { get; set; }

        [Required(ErrorMessage = "Please enter vehicle registration number")]
        [DisplayName("Vehicle Reg. Number")]
        [StringLength(30, ErrorMessage = "Vehicle registration number cannot be greater than 30 characters.")]
        public string Vehicle { get; set; }

        // Appointment colour to be shown for each appointment in the appointments calendar
        public string Color { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Check if end date is greater than start date and flag an error
            if (EndDate < StartDate)
            {
                // Show error on EndDate and use yield as return type is IEnumerable
                yield return
                  new ValidationResult(errorMessage: "Appointment cannot end before it starts. Please edit the end date.",
                                       memberNames: new[] { "EndDate" });
            }
        }
    }
}
