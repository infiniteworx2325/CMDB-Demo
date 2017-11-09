using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssetManagementSystem.Models
{
    public class AssetList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Asset> list = new List<Asset>();
        public List<string> selectedList { get; set; }
    }
}