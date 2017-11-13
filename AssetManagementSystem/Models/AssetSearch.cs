using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetManagementSystem.Models
{
    public class AssetSearch
    {
        [DisplayName("Asset Id ")]
        public int assetId { get; set; }
        [DisplayName("Asset Code")]
        public string assetCode { get; set; }
        [DisplayName("Asset Name")]
        public string assetName { get; set; }
        [DisplayName("Short Name")]
        public string shortName { get; set; }
        [DisplayName("Description")]
        public string description { get; set; }
        [DisplayName("Serial No")]
        public string serialNo { get; set; }
        [DisplayName("Model No")]
        public string  modelNo { get; set; }
        [DisplayName("Warranty Period")]
        public int warrantyPeriod { get; set; }
        [DisplayName("Vendor Name")]
        public string vendorName { get; set; }
        [DisplayName("Vendor Contact")]
        public string vendorContact { get; set; }
        [DisplayName("Vendor Email")]
        public string vendorEmail { get; set; }
        [DisplayName("Created Date")]
        public DateTime createdDate { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; }
        public bool isconfig { get; set; }
        public bool isAssigned { get; set; }
        [DisplayName("Emp Id No")]
        public string empId { get; set; }
        [DisplayName("Emp Name ")]
        public string empName { get; set; }
        [DisplayName("Cubical No ")]
        public int? cubicalNo { get; set; }
        [DisplayName("Contact No ")]
        public string contactNo { get; set; }
        [DisplayName("Email Id ")]
        public string emailId { get; set; }
       // public List<Asset> list = new List<Asset>();
       // public List<string> selectedList { get; set; }
       // public List<Employee> empList = new List<Employee>();
    }
}