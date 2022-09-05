using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConferenceTracker.Entities
{
    public class Speaker : IValidatableObject
    {
        [Required]
        public int Id { get; set; }
        [Display(Name = "First name")]
        [Required]
        [StringLength(100, MinimumLength = 2)]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [Display(Name = "Last name")]
        [Required]
        [StringLength(100, MinimumLength = 2)]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 10)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public bool IsStaff { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            var validationResults = new List<ValidationResult>();

            var splitEmail = EmailAddress.Split('@');
            var emailForCompare = splitEmail[1];

            if (EmailAddress != null && string.Compare(emailForCompare, "TechnologyLiveConference.com", StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                var error = new ValidationResult("Technology Live Conference staff should not use their conference email addresses.");
                validationResults.Add(error);
            }

            return validationResults;
        }
    }
}
