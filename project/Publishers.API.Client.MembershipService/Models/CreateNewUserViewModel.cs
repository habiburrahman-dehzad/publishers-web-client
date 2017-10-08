using Publishers.API.Client.MembershipService.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Publishers.API.Client.MembershipService.Models
{
    public class CreateNewUserViewModel
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
        [Compare("Password", ErrorMessage = "The password and confirmed password do not match.")]
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

        [Display(Name = "Access Fail Count")]
        public int AccessFailedCount { get; set; }

        [Display(Name = "Confirmed Email")]
        public bool EmailConfirmed { get; set; }

        //
        // Summary:
        //     Is lockout enabled for this user
        [Display(Name = "Lockout Enabled")]
        public bool LockoutEnabled { get; set; }

        //
        // Summary:
        //     DateTime in UTC when lockout ends, any time in the past is considered not
        //     locked out.
        [Display(Name = "Lockout End Date in UTC")]
        public DateTime? LockoutEndDateUtc { get; set; }

        //
        // Summary:
        //     User name
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "You must enter a registered university name.")]
        public string University { get; set; }

        public ApplicationUser ToApplicationUser()
        {
            ApplicationUser user = new ApplicationUser
            {
                Email = this.Email,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Address = this.Address,
                City = this.City,
                State = this.State,
                PostalCode = this.PostalCode,
                Country = this.Country,
                AccessFailedCount = this.AccessFailedCount,
                EmailConfirmed = this.EmailConfirmed,
                LockoutEnabled = this.LockoutEnabled,
                LockoutEndDateUtc = this.LockoutEndDateUtc,
                UserName = this.UserName,
                University = this.University
            };

            return user;
        }

        public CreateNewUserViewModel()
        {

        }

        public CreateNewUserViewModel(ApplicationUser user)
        {
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Address = user.Address;
            City = user.City;
            State = user.State;
            PostalCode = user.PostalCode;
            Country = user.Country;
            AccessFailedCount = user.AccessFailedCount;
            EmailConfirmed = user.EmailConfirmed;
            LockoutEnabled = user.LockoutEnabled;
            LockoutEndDateUtc = user.LockoutEndDateUtc;
            UserName = user.UserName;
            University = user.University;
        }
    }
}
