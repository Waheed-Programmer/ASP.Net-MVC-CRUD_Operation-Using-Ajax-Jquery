using CRUD_Asp_MVC__JQuery_Ajax_.Models;
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
            ViewBag.city = (from obj in DB.CityTables
                            
                            select new SelectListItem()
                            {
                                Text = obj.CItyName,
                                Value = obj.CityId.ToString()
                            }
                            
                            
                            ).ToList();
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
       
    }
}