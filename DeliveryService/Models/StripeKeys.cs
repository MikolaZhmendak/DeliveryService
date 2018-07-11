using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliveryService.Models
{
    public class StripeKeys
    {
        public string SecretKey { get; set; }
        public string PublishableKey { get; set; }
    }
}