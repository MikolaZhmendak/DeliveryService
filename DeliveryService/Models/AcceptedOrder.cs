using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DeliveryService.Models
{
    public class AcceptedOrder
    {

        [Key]
        public int AcceptedOrderId { get; set; }

        public int? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }


        public int? OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual CustomerOrder CustomerOrder { get; set; }

        public bool Yes { get; set; }
        public bool No { get; set; }

        

    }
}