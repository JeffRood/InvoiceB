using InvoiceBE.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InvoiceBE.ContextDB
{
    public class InvoiceContext: DbContext
    {
        public InvoiceContext() : base("name=FacturacionContext")
        {
        }
        public DbSet<Product> Product { get; set; }
       
        public System.Data.Entity.DbSet<InvoiceBE.Models.Employee> Employee { get; set; }
        public System.Data.Entity.DbSet<InvoiceBE.Models.Client> Clients { get; set; }


        public System.Data.Entity.DbSet<InvoiceBE.Models.Invoice> Invoices { get; set; }

        public System.Data.Entity.DbSet<InvoiceBE.Models.InvoiceDetails> InvoiceDetails { get; set; }

        public System.Data.Entity.DbSet<InvoiceBE.Models.Login> Logins { get; set; }
    }
}