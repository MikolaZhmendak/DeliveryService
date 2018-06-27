using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeliveryService.Models
{
    public class CustomerOrder
    {
        [Key]
        public int OrderId { get; set; }
        public string RestaurantName { get; set; }
        public string ItemOrdered { get; set; }
        public int Quantity { get; set; }


        [DisplayName("Date of Order")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date_of_Order { get; set; }

        public bool CurbeSide { get; set; }
        public bool WalkIn {get; set;}

        public int Tips { get; set; }

    }
}