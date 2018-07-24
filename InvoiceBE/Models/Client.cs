using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvoiceBE.Models
{
    public class Client
    {
        [Key]
        public int ClientID { get; set; }

        [Required(ErrorMessage = "You must enter {0} ")]
        [StringLength(30, ErrorMessage = "The Field {0} must be between {2} and {1} character", MinimumLength = 3)]
        public string Name { get; set; }


        [Required(ErrorMessage = "You must enter {0} ")]
        [StringLength(30, ErrorMessage = "The Field {0} must be between {2} and {1} character", MinimumLength = 5)]
        public string Document { get; set; }

        [DataType(DataType.CreditCard)]
        public string AccountingAccount { get; set; }

        public Status ClientStatus { get; set; }

        [JsonIgnore]
        public virtual ICollection<Invoice> Invoice { get; set; }

    }
}