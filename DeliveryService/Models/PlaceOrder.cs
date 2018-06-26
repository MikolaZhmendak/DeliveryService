using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeliveryService.Models
{
    public class PlaceOrder
    {
        [Key]
        public int PlaceOrderId { get; set; }

        public string RestaurantName { get; set; }

        public string ItemOrdered { get; set; }

        public int Quantity { get; set; }

        public bool DoorStepDelivery { get; set; }
    }
}