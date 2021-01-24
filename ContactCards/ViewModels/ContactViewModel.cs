using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCards.ViewModels
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Enter full name")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Enter some information")]
        public string Note { get; set; }

        [Required(ErrorMessage = "Enter an email address")]
        [DataType(DataType.Password)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter a facebook account")]
        public string Facebook { get; set; }

        [Required(ErrorMessage = "Enter a twitter account")]
        public string Twitter { get; set; }

        [Required(ErrorMessage = "Attach a photo")]
        public IFormFile Image { get; set; }
    }
}
