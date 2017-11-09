using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetManagementSystem.Models
{
    public class Employee
    {
        [DisplayName("Sr No ")]
        public int srNo { get; set; }

        [DisplayName("Emp Id ")]
        [Required(ErrorMessage = "Enter Employee id")]
        public string empId { get; set; }
        [DisplayName("Emp Name ")]
        [Required(ErrorMessage = "Enter Employee Name")]
        public string empName { get; set; }
        [DisplayName("Cubical No ")]
        [Required(ErrorMessage = "Enter Employee Cubical Number")]
        public int cubicalNo { get; set; }
        [DisplayName("Contact No ")]
        [Required(ErrorMessage = "Please Enter Contact No")]
        //[RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter Valid Contact Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string contactNo { get; set; }
        [DisplayName("Email Id ")]
        [Required(ErrorMessage = "Enter Email Id")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string emailId { get; set; }
    }
}