using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeliveryService.Models
{
    public class Driver
    {
        [Key]
        public int DriverId { get; set; }

        [StringLength(50)]
        [Display(Name = "First Name")]
        public virtual string FirstName { get; set; }

        [StringLength(50)]
        [Display(Name = "Last Name")]
        public virtual string LastName { get; set; }

        [DisplayFormat(DataFormatString = "{0: ###-####-####}")]
        public long PhoneNumber { get; set; }

        [DataType(DataType.PostalCode)]
        public virtual string ZipCode { get; set; }




    }
}