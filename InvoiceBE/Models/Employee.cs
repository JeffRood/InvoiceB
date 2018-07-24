using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvoiceBE.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "You must enter {0} ")]
        [StringLength(30, ErrorMessage = "The Field {0} must be between {2} and {1} character", MinimumLength = 3)]
        public string Name { get; set; }



        [DisplayFormat(DataFormatString = "{0:p2}", ApplyFormatInEditMode = false)]
        public float BonusPercent { get; set; }



        public Status EmployeeStatus { get; set; }


        [JsonIgnore]
        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}