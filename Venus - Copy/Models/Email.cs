using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Venus.Models
{
    public class Email
    {
        [Key]
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
