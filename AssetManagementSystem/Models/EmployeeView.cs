using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssetManagementSystem.Models
{
    public class EmployeeView
    {
        public Employee employee { get; set; }
        public List<AllocatedAsstesViewModel> assetList { get; set; }
    }
}