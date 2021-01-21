using System;
using System.Collections.Generic;

#nullable disable

namespace ContactCards.Models
{
    public partial class Contact
    {
        public int Id { get; set; }

        public string Fullname { get; set; }

        public DateTime? Lasttimeaccess { get; set; }

        public string Note { get; set; }

        public string Email { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public string Imagepath { get; set; }
    }
}
