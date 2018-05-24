using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DeliveryService.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }


        public int? DriverId { get; set; }
        [ForeignKey("DriverId")]
        public virtual Driver Driver { get; set; }

        [Required]
        public string LicenceState { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0: ####-####-####-##}")]
        public long DrivingLicence { get; set; }





    }
}