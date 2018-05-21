using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DeliveryService.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }


        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual CustomerOrderHistory CustomerOrderHistory { get; set; }



        [Required(ErrorMessage = " First Name is required")]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public virtual string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public virtual string LastName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(70)]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(40)]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [StringLength(40)]
        public string State { get; set; }

        [Required(ErrorMessage = "Postal Code is required")]
        [DisplayName("Postal Code")]
        [StringLength(10)]
        public string PostalCode { get; set; }

        [DisplayFormat(DataFormatString = "{0: ###-####-####}")]
        public long PhoneNumber { get; set; }

    }
}