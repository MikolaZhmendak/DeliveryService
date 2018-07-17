using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeliveryService.Models
{
    public class OrderDriverView
    {
        [Key]
        public int OrderDriverViewID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }


        [DataType(DataType.PhoneNumber), DisplayFormat(DataFormatString = "{0:(###)-###-####}", ApplyFormatInEditMode = true)]
        public long PhoneNumber { get; set; }

        public string RestaurantName { get; set; }
        public string ItemOrdered { get; set; }
        public int Quantity { get; set; }

        public bool CurbeSide { get; set; }
        public bool WalkIn { get; set; }

        public int Tips { get; set; }

    }
}