using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceBE.Models
{
    public class Login
    {
        [key]
        public int LoginID { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

    }
}