using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetManagementSystem.Models
{
    public class Asset
    {
        public int assetId { get; set; }
        public int resourceId { get; set; }
        [Required(ErrorMessage = "Asset Code is required.")]

        [DisplayName("Asset Code")]
        public string assetCode { get; set; }
        [DisplayName("Asset Name")]

        [Required(ErrorMessage = "Asset Name is required.")]
        public string assetName { get; set; }
        [DisplayName("Short Name")]

        [Required(ErrorMessage = "Short Name is required.")]
        public string shortName { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [DisplayName("Description")]
        public string description { get; set; }

        [Required(ErrorMessage = "SerialNo is required.")]
        [DisplayName("SerialNo")]
        public string serialNo { get; set; }

        [Required(ErrorMessage = "ModelNo is required.")]
        [DisplayName("ModelNo")]
        public string modelNo { get; set; }

        [Required(ErrorMessage = "Software Version is required.")]
        [DisplayName("Software Version")]
        public string softwareVersion { get; set; }

        [Required(ErrorMessage = "Software Type is required.")]
        [DisplayName("Software Type")]
        public string softwareType { get; set; }

        [Required(ErrorMessage = "Licence Class is required.")]
        [DisplayName("Licence Class")]
        public string licenceClass { get; set; }

        [Required(ErrorMessage = "Licence Number is required.")]
        [DisplayName("Licence Number")]
        public string licenceNumber { get; set; }

        [Required(ErrorMessage = "Licence Key is required.")]
        [DisplayName("Licence Key")]
        public string licenceKey { get; set; }

        [Required(ErrorMessage = "Warranty Period is required.")]
        [DisplayName("Warranty Period")]
        public int warrantyPeriod { get; set; }

        [Required(ErrorMessage = "Vendor Name is required.")]
        [DisplayName("Vendor Name")]
        public string vendorName { get; set; }

        [Required(ErrorMessage = "Vendor Contact is required.")]
        [DisplayName("Vendor Contact")]
        public string vendorContact { get; set; }

        [Required(ErrorMessage = "Vendor Email is required.")]
        [DisplayName("Vendor Email")]
        public string vendorEmail { get; set; }

        [DisplayName("Created Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Created date is required.")]
        public DateTime createdDate { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; }

        public Asset()
        {
            assetId = 0;

            resourceId = 0;
            assetCode = string.Empty;
            assetName = string.Empty;
             shortName = string.Empty;
             description = string.Empty;
             serialNo = string.Empty;
             modelNo = string.Empty;
             softwareVersion = string.Empty;
             softwareType = string.Empty;
             licenceClass = string.Empty;
             licenceNumber = string.Empty;
             licenceKey = string.Empty;
             warrantyPeriod = 0;
             vendorName = string.Empty;
             vendorContact = string.Empty;
             vendorEmail = string.Empty;
             createdDate = DateTime.MinValue;
         

    }
}
}