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
        [Range (0,16)]
        public  int CreditCardNumber { get; set; }

        public  PaymentType CardType { get; set; }
        [Range(0,5)]
        public  int ExparationDate { get; set; }

        [Range (0,3)]
        public  int CVC { get; set; }
    }

    public enum PaymentType
    {
        MasterCard,
        Visa,
        AmericanExpress,
    }

}