using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeliveryService.Models
{
    public class Employer
    {
        [Key]

        public string FirstName { get; set; }


        public string LastName { get; set; }


        [DisplayFormat(DataFormatString = "{0: ###-####-####}")]
        public long PhoneNumber { get; set; }
    }
}