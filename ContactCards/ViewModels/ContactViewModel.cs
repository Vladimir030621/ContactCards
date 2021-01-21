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
        [Required]
        public string Fullname { get; set; }

        [Required]
        public string Note { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Facebook { get; set; }

        [Required]
        public string Twitter { get; set; }

        [Required]
        public IFormFile Image { get; set; }
    }
}
