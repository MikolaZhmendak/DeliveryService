using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeliveryService.Models
{
    public class FinishOrder
    {
        [Key]
        public int FinishOrderId { get; set; }
        public bool Yes { get; set; }
    }
}