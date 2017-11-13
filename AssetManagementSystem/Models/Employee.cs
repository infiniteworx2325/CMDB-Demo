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

        [DisplayName("Emp Id No")]
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
        [RegularExpression(@"^(((\+){0,1}91|0)(\s){0,1}(\-){0,1}(\s){0,1}){0,1}[7-9][0-9](\s){0,1}(\-){0,1}(\s){0,1}[1-9]{1}[0-9]{7}$", ErrorMessage = "Enter Valid Contact Number")]
        public string contactNo { get; set; }
        [DisplayName("Email Id ")]
        [Required(ErrorMessage = "Enter Email Id")]
        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        //[DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        //[EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string emailId { get; set; }
    }
}