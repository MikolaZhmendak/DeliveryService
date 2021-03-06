﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public int? DriverId { get; set; }
        [ForeignKey("DriverId")]
        public virtual Driver Driver { get; set; }

        [MinimumAge(18)]
        [Required(ErrorMessage = "Date of Birth required")]
        [DisplayName("Date of Birth")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date_of_Birth { get; set; }

        //    [Required(ErrorMessage = "SSN is required")]
        //      [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###-##-####}")]
        //    public long Ssn { get; set; }

        [Display(Name = "Social Security")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###-##-####}")]
        public long Ssn { get; set; }

        public string VehicleType { get; set; }

        //    [MinimumAge(22)]
        //  [Required(ErrorMessage = "Must be newer then 1996")]
        [Range(1996, 2018,
             ErrorMessage = " The year for{0} must be between {1} and {2}.")]
        public int VehicleYear { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:####-####-####-##}")]
        public long DrivingLicence { get; set; }

        public string LicenceState { get; set; }
        public string InsuranceProvider { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ExpirationDate{ get; set; }
       




    }
}