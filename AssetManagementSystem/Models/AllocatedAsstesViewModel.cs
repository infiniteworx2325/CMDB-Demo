using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssetManagementSystem.Models
{
    public class AllocatedAsstesViewModel
    {
        public int assetId { get; set; }
        public string empId { get; set; }
        public int srNo { get; set; }
        public string assetName { get; set; }
        public int serialNo { get; set; }
        public string empName { get; set; }
      
    }
}