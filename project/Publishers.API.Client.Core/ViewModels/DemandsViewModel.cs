using Publishers.API.Client.Core.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Publishers.API.Client.Core.ViewModels
{
    public class DemandsViewModel
    {
        [Display(Name = "Books")]
        public List<BookModel> Books { get; set; }
    }
}
