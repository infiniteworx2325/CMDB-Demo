using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AssetManagementSystem.Models
{
    public class Other : IValidatableObject
    {
        public int assetId { get; set; }
        public int resourceId { get; set; }

        [Required(ErrorMessage = "Asset Code is required.")]
        [DisplayName("Asset Code")]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]
        public string assetCode { get; set; }

        [DisplayName("Asset Name")]
        [Required(ErrorMessage = "Asset Name is required.")]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]
        [MaxLength(30, ErrorMessage = "Name cannot be longer than 30 characters.")]
        public string assetName { get; set; }

        [DisplayName("Short Name")]
        [Required(ErrorMessage = "Short Name is required.")]
        //[RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use alphabets only")]
        [MaxLength(20, ErrorMessage = "Name cannot be longer than 20 characters.")]
        public string shortName { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [DisplayName("Description")]
        public string description { get; set; }

        [Required(ErrorMessage = "SerialNo is required.")]
        [DisplayName("SerialNo")]     
        public string serialNo { get; set; }

        //[Required(ErrorMessage = "ModelNo is required.")]
        //[DisplayName("ModelNo")]
        //public string modelNo { get; set; }

        //[Required(ErrorMessage = "Software Version is required.")]
        //[DisplayName("Software Version")]
        //public string softwareVersion { get; set; }

        //[Required(ErrorMessage = "Software Type is required.")]
        //[DisplayName("Software Type")]
        //public string softwareType { get; set; }

        //[Required(ErrorMessage = "Licence Class is required.")]
        //[DisplayName("Licence Class")]
        //public string licenceClass { get; set; }

        //[Required(ErrorMessage = "Licence Number is required.")]
        //[DisplayName("Licence Number")]
        //public string licenceNumber { get; set; }

        //[Required(ErrorMessage = "Licence Key is required.")]
        //[DisplayName("Licence Key")]
        //public string licenceKey { get; set; }

        [Required(ErrorMessage = "Warranty Period is required.")]
        [DisplayName("Warranty Period in months")]
        [Range(0, 99, ErrorMessage = "Enter minimum 1 digit and Maximum 2 digits")]
     //   [RegularExpression(@"^(\d{2})$", ErrorMessage = "Enter Warranty in months i.e.Max two digit ")]
        public int warrantyPeriod { get; set; }

        [Required(ErrorMessage = "Vendor Name is required.")]
        [DisplayName("Vendor Name")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use alphabets only")]
        [MaxLength(30, ErrorMessage = "Name cannot be longer than 30 characters.")]
        public string vendorName { get; set; }

        [Required(ErrorMessage = "Vendor Contact is required.")]
        [RegularExpression(@"^(((\+){0,1}91|0)(\s){0,1}(\-){0,1}(\s){0,1}){0,1}[7-9][0-9](\s){0,1}(\-){0,1}(\s){0,1}[1-9]{1}[0-9]{7}$", ErrorMessage = "Enter Valid Contact Number")]
        //  [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        [DisplayName("Vendor Contact")]
        public string vendorContact { get; set; }

        [Required(ErrorMessage = "Vendor Email is required.")]
        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        [DisplayName("Vendor Email")]
        public string vendorEmail { get; set; }

        [DisplayName("Created Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Created date is required.")]
        public DateTime createdDate { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (createdDate > DateTime.Now)
            {
                results.Add(new ValidationResult("Please enter valid date", new[] { "createdDate" }));
            }

            return results;
        }


        public bool isActive { get; set; }
        public bool isDeleted { get; set; }
        public bool isAssigned { get; set; }



        public Other()
        {
            resourceId = 3;
            assetId = 0;

            assetCode = string.Empty;
            assetName = string.Empty;
            shortName = string.Empty;
            description = string.Empty;
            serialNo = string.Empty;
            warrantyPeriod = 0;
            vendorName = string.Empty;
            vendorContact = string.Empty;
            vendorEmail = string.Empty;
            createdDate = DateTime.Today;
        }
    }
}