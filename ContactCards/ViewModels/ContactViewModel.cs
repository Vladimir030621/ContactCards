using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCards.ViewModels
{
    public class ContactViewModel
    {
        public string Fullname { get; set; }

        public string Note { get; set; }

        public string Email { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public IFormFile Image { get; set; }
    }
}
