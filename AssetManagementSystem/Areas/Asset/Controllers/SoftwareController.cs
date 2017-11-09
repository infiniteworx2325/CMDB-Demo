using AssetManagementSystem.DataAccessLayer;
using AssetManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssetManagementSystem.Areas.Asset.Controllers
{
    public class SoftwareController : Controller
    {
        // GET: Asset/Software
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            Software software = new Software();
            return View(software);
        }
        [HttpPost]
        public ActionResult Create(Software software)
        {
            if (ModelState.IsValid)
            {
                AssetService assetService = new AssetService();
                int result = assetService.AddSoftwareAsset(software);
                if (result > 0) {
                    ModelState.Clear();
                    ViewBag.Msg = "Asset saved successfully";
                }
                
            }

            //return RedirectToAction("Create", "Software");
            return View();
        }



        [HttpGet]
        public ActionResult Softwares()
        {
            List<Software> sw = new List<Software>();
            AssetService assetService = new AssetService();
            sw = assetService.GetSoftwares();
            return View(sw);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            AssetService assetService = new AssetService();
            Software software = assetService.GetSoftware(id);
            return View(software);
        }
        //[HttpPost]
        //public ActionResult Edit(Software software)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            //model.Type = 1;
        //            AssetService assetService = new AssetService();
        //            int res = assetService.UpdateSoftware(software);
        //            if (res > 0)
        //            {
        //                return RedirectToAction("Softwares");
        //            }

        //            return View(software);
        //        }
        //        catch
        //        {

        //        }
        //    }
        //    return View(software);
        //}

        [HttpPost]
        public ActionResult Edit(Software software)
        {
            //if (ModelState.IsValid)
            //{
            //    AssetService assetService = new AssetService();
            //    int result = assetService.UpdateSoftware(software);
            //    if (result > 0)
            //    {
            //           ViewBag.Msg = "Asset updated successfully";
            //    }
            //}

            //return RedirectToAction("Softwares");

            if (ModelState.IsValid)
            {
                try
                {

                    AssetService assetService = new AssetService();
                    int res = assetService.UpdateSoftware(software);
                    if (res > 0)
                    {
                        return RedirectToAction("Softwares");
                    }

                    return View(software);
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
            int result = assetService.SoftDeleteSoftware(id);
            if (result > 0)
            {
                TempData["IsDeleteMsg"] = "Deleted Successfully";
            }

            return RedirectToAction("Softwares");

        }

    }
}