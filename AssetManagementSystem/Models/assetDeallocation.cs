using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssetManagementSystem.Models
{
    public class assetDeallocation
    {
        public int srNo { get; set; }
        public List<int> selectedAssets { get; set; }
    }
}