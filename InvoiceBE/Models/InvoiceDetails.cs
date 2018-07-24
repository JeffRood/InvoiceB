using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvoiceBE.Models
{
    public class InvoiceDetails
    {
        [Key]
        public int FacturaDetailID { get; set; }

        public int DetailID { get; set; }

        public int ProductID { get; set; }

        [Display(Name = "Cantidad")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = false)]
        public float Quantity { get; set; }


        // Coneccion Virtuales
         public virtual Invoice Invoice { get; set; }
         public virtual Product Product { get; set; }
    }
}