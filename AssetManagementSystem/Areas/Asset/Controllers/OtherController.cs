using AssetManagementSystem.DataAccessLayer;
using AssetManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssetManagementSystem.Areas.Asset.Controllers
{
    public class OtherController : Controller
    {
        // GET: Asset/Other
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            Other other = new Other();
            return View(other);
        }

        public ActionResult Create(Other other)
        {
            if (ModelState.IsValid)
            {
                AssetService assetService = new AssetService();
                int result = assetService.AddOtherAsset(other);
                if (result > 0)
                {
                    ModelState.Clear();
                    ViewBag.Msg = "Asset saved successfully";
                }
            }

            // return RedirectToAction("Create", "Other");
            return View();
        }



        [HttpGet]
        public ActionResult Others()
        {
            List<Other> ot = new List<Other>();
            AssetService assetService = new AssetService();
           ot = assetService.GetOthers();
            return View(ot);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            AssetService assetService = new AssetService();
            Other ot = assetService.GetOther(id);
            return View(ot);
        }
        [HttpPost]
        public ActionResult Edit(Other other)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    AssetService assetService = new AssetService();
                    int res = assetService.UpdateOther(other);
                    if (res > 0)
                    {
                        ViewBag.Msg = "Data Updated successfully....";
                        //return RedirectToAction("Others");
                    }

                    return View(other);
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
            int result = assetService.SoftDeleteOther(id);
            if (result > 0)
            {
                TempData["IsDeleteMsg"] = "Deleted Successfully";
            }

            return RedirectToAction("Others");

        }

    }
}