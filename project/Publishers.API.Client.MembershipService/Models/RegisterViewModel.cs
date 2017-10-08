using System.ComponentModel.DataAnnotations;

namespace Publishers.API.Client.MembershipService.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(160, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(160, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "You must provide a valid address.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "You must provide a valid city name.")]
        public string City { get; set; }

        [Required(ErrorMessage = "You must provide a valid state or province name.")]
        [Display(Name = "State/Province")]
        public string State { get; set; }

        [Required(ErrorMessage = "You must provide a valid zip/postal code.")]
        [Display(Name = "Zip/Postal")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "You must provide a valid country name.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "You must enter a registered university name.")]
        public string University { get; set; }
    }
}
