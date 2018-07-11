using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeliveryService.Models
{
    public class Restaurant
    {
        [Key]

        public int RestaurantId { get; set; }

        public string Name { get; set; }

        public int ZipCode { get; set; }

        public string Url { get; set; }
    }
}