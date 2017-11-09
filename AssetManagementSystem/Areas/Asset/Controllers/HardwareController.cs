using AssetManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetManagementSystem.DataAccessLayer;
namespace AssetManagementSystem.Areas.Asset.Controllers
{
    public class HardwareController : Controller
    {
        // GET: Asset/Hardware
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Demo()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            Hardware hardware = new Hardware();
            return View(hardware);
        }

        public ActionResult Create(Hardware hardware)
        {
            if (ModelState.IsValid)
            {
                AssetService assetService = new AssetService();
                int result = assetService.AddHardwareAsset(hardware);
                if (result > 0)
                {
                    ModelState.Clear();
                    ViewBag.Msg = "Asset saved successfully";

                    //TempData["savemsg"] = "Asset saved successfully";
                    
                }
                
            }
            return View();
           // return RedirectToAction("Hardwares", "Hardware");
            
        }
       


        [HttpGet]
        public ActionResult Hardwares()
        {
            List<Hardware> list = new List<Hardware>();
            AssetService assetService = new AssetService();
            list = assetService.GetHardwares();
            return View(list);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            AssetService assetService = new AssetService();
            Hardware sm = assetService.GetHardware(id);
            return View(sm);
        }
        [HttpPost]
        public ActionResult Edit(Hardware hardware)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   
                    AssetService assetService = new AssetService();
                    int res = assetService.UpdateHardware(hardware);
                    if (res > 0)
                    {
                        return RedirectToAction("Hardwares");
                    }

                    return View(hardware);
                }
                catch
                {

                }
            }
            return View();
        }
        

        [HttpPost]
        public ActionResult Delete(int id)
        {
            AssetService assetService = new AssetService();
            int result = assetService.SoftDeleteHardware(id);
            if (result > 0) {
                TempData["IsDeleteMsg"] = "Deleted Successfully";
                    }

            return RedirectToAction("Hardwares");
            
        }

    }
}