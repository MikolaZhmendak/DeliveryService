using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DeliveryService.Models
{
    public class InsuranceInfromation
    {
        [Key]

        public int InsuranceInformationId { get; set; }


        public int? DriverId { get; set; }
        [ForeignKey("DriverId")]
        public virtual Driver Driver { get; set; }

        public string InsuranceProvider { get; set; }

        [DisplayName("Expiration Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Expiration_Date { get; set; }
    }
}