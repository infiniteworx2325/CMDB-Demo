using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssetManagementSystem.Models
{
    public class ConfiguredAssetEmployee
    {
        public int srNo { get; set; }
        public List<int> selectedAssets { get; set; }
    }
}