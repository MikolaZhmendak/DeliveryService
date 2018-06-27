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
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date_of_Order { get; set; }

    }
}