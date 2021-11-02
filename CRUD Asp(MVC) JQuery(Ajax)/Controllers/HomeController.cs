using CRUD_Asp_MVC__JQuery_Ajax_.Models;
using CRUD_Asp_MVC__JQuery_Ajax_.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Asp_MVC__JQuery_Ajax_.Controllers
{
    public class HomeController : Controller
    {
        EmployeManagementEntities DB = new EmployeManagementEntities();
        public ActionResult Index()
        {
            List<CityTable> DeptList = DB.CityTables.ToList();
            ViewBag.city = new SelectList(DeptList, "CityId", "CItyName");
            return View();
        }
        [HttpGet]
        public JsonResult GetEmploye()
        {
            var employe = (from objemp in DB.EmployeTables
                           join
                           objcities in DB.CityTables on objemp.CityId equals objcities.CityId
                           select new
                           {
                               EmoloyeId = objemp.EmoloyeId,
                               Name = objemp.Name,
                               Age = objemp.Age,
                               CityId = objcities.CityId,
                               CItyName= objcities.CItyName
                           }
                           ).ToList();
            return Json(new { Success = true, data = employe }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddUpdateEmploye(ViewModelEmploye view)
        {
            string Message = "Data has been updated";
            //EmployeTable objEmploye = new EmployeTable();
            EmployeTable objEmploye = DB.EmployeTables.SingleOrDefault(model => model.EmoloyeId == view.EmoloyeId) ?? new EmployeTable();
            objEmploye.EmoloyeId = view.EmoloyeId;
            objEmploye.Name = view.Name;
            objEmploye.Age = view.Age;
            objEmploye.CityId = view.CityId;

            if (objEmploye.EmoloyeId == 0)
            {
                Message = "Data has been Inserted";
                DB.EmployeTables.Add(objEmploye);
                DB.SaveChanges();
            }
            

            return Json(new {Success=true,Message=Message }, JsonRequestBehavior.AllowGet);
        }
       
    }
}