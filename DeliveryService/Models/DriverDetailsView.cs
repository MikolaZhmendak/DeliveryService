using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeliveryService.Models
{
    public class DriverDetailsView
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string VehicleType { get; set; }
        public int VehicleYear { get; set; }


        public string LicenceState { get; set; }


        [DisplayFormat(DataFormatString = "{0: ####-####-####-##}")]
        public long DrivingLicence { get; set; }

        public string InsuranceProvider { get; set; }

        [DisplayName("Expiration Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Expiration_Date { get; set; }
    }
}