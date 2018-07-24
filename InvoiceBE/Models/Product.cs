using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvoiceBE.Models
{
    public class Product
    {
        [Key]

        public int ProductID { get; set; }
        [Display(Name = "Descripcion ")]
        public string Description { get; set; }

        [Display(Name = "Precio Unitario")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }

        [Display(Name = "Disponibilidad")]
        public float Stock { get; set; }


     

        [JsonIgnore]
        public virtual ICollection<InvoiceDetails> InvoiceDetails { get; set; }

    }
}