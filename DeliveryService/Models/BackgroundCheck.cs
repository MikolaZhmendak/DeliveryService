using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DeliveryService.Models
{
    public class BackgroundCheck
    {

        [Key]

        public int BackgroundId { get; set; }

        [Required]
        public int DriverId { get; set; }
        [ForeignKey("DriverID")]
        public virtual Driver Driver { get; set; }


        public string VehicleType { get; set; }




    }
}