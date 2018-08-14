using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeliveryService.Models
{
    public class AccetpOrder
    {
        [Key]
        public int AccetpOrderId { get; set; }
        public bool Yes { get; set; }
        public bool No { get; set; }
    }
}