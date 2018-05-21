using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeliveryService.Models
{
    public class CustomerOrderHistory
    {
        [Key]
        public int OrderId { get; set; }

        public string RestaurantName { get; set; }

        public string ItemOrdered { get; set; }

        public int Quantity { get; set; }
         


    }
}