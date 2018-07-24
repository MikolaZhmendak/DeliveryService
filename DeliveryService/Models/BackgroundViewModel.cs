using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DeliveryService.Models
{
    public class BackgroundViewModel
    { 
        public int BackgroundId { get; set; }

        public int? DriverId { get; set; }
        [ForeignKey("DriverId")]
        public virtual Driver Driver { get; set; }

        [MinimumAge(18)]
        [Required(ErrorMessage = "Date of Birth required")]
        [DisplayName("Date of Birth")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date_of_Birth { get; set; }


        [Display(Name = "Social Security")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###-##-####}")]
        public long Ssn { get; set; }

        public string VehicleType { get; set; }
        public int VehicleYear { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:####-####-####-##}")]
        public long DrivingLicence { get; set; }

        public string LicenceState { get; set; }
        public string InsuranceProvider { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ExpirationDate { get; set; }

        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

        [DataType(DataType.PhoneNumber), DisplayFormat(DataFormatString = "{0:(###)-###-####}", ApplyFormatInEditMode = true)]
        public long PhoneNumber { get; set; }

      
    }
}