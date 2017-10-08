using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Publishers.API.Client.Core.Models
{
    public class UserMessageModel
    {
        [Required(ErrorMessage = "Please type in your full name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "You should provide a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please provide a valid phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please type your message, it is required")]
        public string Message { get; set; }
    }
}