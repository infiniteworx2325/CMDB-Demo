using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetManagementSystem.DataAccessLayer;
using AssetManagementSystem.Models;
//using PagedList;

namespace AssetManagementSystem.Controllers
{
    public class SearchAssetController : Controller
    {
        // GET: SearchAsset
        public ActionResult Index()
        {
            AssetListSearchService assetListSearchService = new AssetListSearchService();
            List<AssetSearch> list = new List<AssetSearch>();
            list = assetListSearchService.GetAllAssetsList();
            return View(list);
        }
        public ActionResult AssetSearch()
        {
            AssetListSearchService assetListSearchService = new AssetListSearchService();
            List<AssetSearch> list = new List<AssetSearch>();
            list = assetListSearchService.GetAllAssetsList();
            return View(list);
        }
    }
}