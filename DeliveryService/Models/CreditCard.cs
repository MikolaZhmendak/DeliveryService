using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeliveryService.Models
{
    public class CreditCard
    {
        [Key]
        public int CreditCardId { get; set; }
        
        public  int CreditCardNumber { get; set; }

        public  PaymentType CardType { get; set; }
        
        public  int ExparationDate { get; set; }

      
        public  int CVC { get; set; }
    }

    public enum PaymentType
    {
        MasterCard,
        Visa,
        AmericanExpress,
    }

}