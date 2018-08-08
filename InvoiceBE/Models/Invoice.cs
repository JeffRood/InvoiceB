using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceBE.Models
{
    public class Invoice
    {
        [key]
        public int InvoiceID { get; set; }

        public int EmployeeID { get; set; }

        public int ClientID { get; set; }

        public string Date { get; set; }

        public string Remark { get; set; }


        public ICollection<InvoiceDetails> Details { get; set; }
        [JsonIgnore]
        public virtual Client Clients { get; set; }
        [JsonIgnore]
        public virtual Employee Employees { get; set; }



    }
}