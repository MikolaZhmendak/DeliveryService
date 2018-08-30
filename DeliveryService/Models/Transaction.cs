using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliveryService.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string Month { get; set; }
        public int Transaction_Cost { get; set; }

    }
}