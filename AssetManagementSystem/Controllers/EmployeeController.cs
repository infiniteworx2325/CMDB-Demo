using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetManagementSystem.DataAccessLayer;
using AssetManagementSystem.Models;
using System.Collections;

namespace AssetManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        //public ActionResult Index()
        //{
        //    return View();
        //extra Hello welcome to Git
        //}

        [HttpGet]
        public ActionResult Assign(int srNo)
        {
            //DataAccessLayer.AssetService AssetService = new AssetService();
            //List<Asset> objAssetList = new List<Asset>();
            //objAssetList = AssetService.GetAssets();
            TempData["srNo"] = srNo;
            return View();
        }

        public ActionResult GetAssetList(int srNo)
        {
            TempData.Keep("srNo");  
            DataAccessLayer.AssetService AssetService = new AssetService();
            List<Asset> objAssetList = new List<Asset>();
            objAssetList = AssetService.GetAssets();
            return Json(objAssetList, JsonRequestBehavior.AllowGet);
        }
        //public ActionResult GetListForConfig(int srNo)
        //{
        //    TempData.Keep("srNo");
        //    DataAccessLayer.AssetService AssetService = new AssetService();
        //    List<Asset> objAssetList = new List<Asset>();
        //    objAssetList = AssetService.GetHardwareSoftwareListForConfig();
        //    return Json(objAssetList, JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public int generateConfigurationGroupId()
        //{
        //    int result = 0;
        //}

        [HttpPost]
        public JsonResult DeallocateAsset(assetDeallocation assetDeallocation)
        {
            AssetService assetService = new AssetService();
            int result = assetService.deleteDeallocatedAssets(assetDeallocation);
            if (result > 0)
            {
                return Json(new { success = true, responseText = "Assets Deallocated successfully." }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { success = false, responseText = "Error while getting allocated assets!!" }, JsonRequestBehavior.AllowGet);

            }
            return null;
        }


        [HttpGet]
        public JsonResult GetAllocatedAssetsList(int srNo)
        {
            DataAccessLayer.AssetService AssetService = new AssetService();
            List<AllocatedAsstesViewModel> listAllocatedAsstesViewModel = new List<AllocatedAsstesViewModel>();

            listAllocatedAsstesViewModel = AssetService.GetAllocatedAssets(srNo);
            if (listAllocatedAsstesViewModel.Count > 0)
            {
                Json(listAllocatedAsstesViewModel, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, responseText = "Error while getting allocated assets!!" }, JsonRequestBehavior.AllowGet);

            }

            return Json(listAllocatedAsstesViewModel, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public JsonResult AssignConfiuredAsset(ConfiguredAssetEmployee configuredAssetEmployee)
        {
            int result = 0;
            string configurationGroupNameId = string.Empty;
            AssetService assetservice = new AssetService();
            EmployeeService employeeService = new EmployeeService();
            int configResult = 0;
            int configAssetAllocation = 0;
            result = assetservice.ConfiguredAssetAllocation(configuredAssetEmployee);

            if (result > 0)
            {
                configurationGroupNameId = assetservice.ConfigurationGroupNameId();
            }
            if (configurationGroupNameId != string.Empty || configurationGroupNameId != null)
            {
                configResult = assetservice.CreateConfiguration(configurationGroupNameId, configuredAssetEmployee.selectedAssets);
            }
            if (configResult > 0)
            {
                for (int i = 0; i < configuredAssetEmployee.selectedAssets.Count; i++)
                {
                    configAssetAllocation = assetservice.AssetAllocation(configuredAssetEmployee.srNo, configuredAssetEmployee.selectedAssets[i]);
                }
            }
            if (configAssetAllocation > 0 && result > 0 && configResult > 0)
            {
                return Json(new { success = true, responseText = "Configured Assets allocated successfully." }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { success = false, responseText = "Error while configured allocation!!" }, JsonRequestBehavior.AllowGet);

            }


        }

        [HttpPost]
        public JsonResult AssignStandaloneAsset(AssetEmployee assetEmployee) {
            int result = 0;
            AssetService assetservice = new AssetService();
            EmployeeService employeeservice = new EmployeeService();
            result = assetservice.AssetAllocation(assetEmployee.srNo, assetEmployee.assetId);
            //      assetservice.AssetAllocation();
            if (result > 0)
            {
                //  Send "false"
                return Json(new { success = true, responseText = "Asset allocated successfully." }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                //  Send "Success"
                return Json(new { success = false, responseText = "Error while allocation!!" }, JsonRequestBehavior.AllowGet);
            }
         //   return Json(new { success = false, responseText = "Your message successfuly sent!" }, JsonRequestBehavior.AllowGet);
        }


            public ActionResult Index()
        {
            
                List<Employee> list = new List<Employee>();
                EmployeeService employeeService = new EmployeeService();
                list = employeeService.GetAllEmployee();
            return View(list);
        }
        //Get method For Add Employee
        [HttpGet]
        public ActionResult Create()
        {
           // return new FilePathResult("C:\\Users\\Shubham Jolapara\\source\\repos\\Ams\\AssetManagementSystem\\AssetManagementSystem\\CMDB\\AssigneeDetails.html", "text/html");
            return View();
        }
        //Post method For Add Employee
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if(ModelState.IsValid == true)
            {
                EmployeeService employeeService = new EmployeeService();

                //employee = employeeService.GetEmployeeBySrNo(employee.srNo);
                if (!employeeService.CheckIfUserAlreadyExist(employee.empId))
                {
                    if (employeeService.AddEmployee(employee) > 0)
                    {
                        ViewBag.Msg = "Employee Added successfully";
                        //return RedirectToAction("Index");
                    }
                    // return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMsg1 = "Employee Id already exist";
                }

            }

            return View(employee);
        }
        // GET: Student/Edit/5
        [HttpGet]
        public ActionResult Edit(int srNo)
        {
            
                EmployeeService employeeService = new EmployeeService();
                Employee employee = employeeService.GetEmployeeBySrNo(srNo);
            
            return View(employee);
                
        }

        [HttpGet]
        public ActionResult View(int srNo)
        {

            EmployeeService employeeService = new EmployeeService();
            EmployeeView employeeView = new EmployeeView();

            employeeView.employee = employeeService.GetEmployeeBySrNo(srNo);

             AssetService assetService = new AssetService();
            employeeView.assetList = assetService.GetAllocatedAssets(srNo);
            return View(employeeView);

        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeService employeeService = new EmployeeService();
                //  int result = employeeService.EditEmployee(employee);
                if (employeeService.EditEmployee(employee) > 0)
                {
                    ViewBag.Msg = "Employee Updated successfully";
                }
                return RedirectToAction("Index");
            }
            return View(employee);

        }

        //public ActionResult Delete(int srNo)
        //{
        //    EmployeeService employeeService = new EmployeeService();
        //    Employee employee = employeeService.GetEmployeeBySrNo(srNo);
        //    return View(employee);
        //}

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int srNo)
        {
            EmployeeService employeeService = new EmployeeService();
            int result = employeeService.DeleteEmployeeBySrNo(srNo);
            if (result > 0)
            {
                TempData["IsDeleteMsg"] = "Deleted Successfully";
            }

            return RedirectToAction("Index");

        
        //EmployeeService employeeService = new EmployeeService();
        //        // TODO: Add delete logic here
        //        int result = employeeService.DeleteEmployeeBySrNo(srNo);
        //        return View(result);
            
        }
    }
}