using CRUD_Asp_MVC__JQuery_Ajax_.Models;
using CRUD_Asp_MVC__JQuery_Ajax_.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Asp_MVC__JQuery_Ajax_.Controllers
{
    public class EmployeController : Controller
    {
        EmployeManagementEntities DB = new EmployeManagementEntities();

        // GET: Employe
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetEmploye()
        {
            //var employe = DB.Employes.ToList();
            return Json(DB.Employes.ToList(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddUpdateEmploye(ViewModelEmploye view)
        {
            string Message = "Data has been updated";
            //Employe e = new Employe();
            Employe e = DB.Employes.SingleOrDefault(model => model.Id == view.Id) ?? new Employe();
            e.Id = view.Id;
            e.Name = view.Name;
            e.Age = view.Age;
            e.Email = view.Email;
            if(e.Id == 0)
            {
                Message = "Data has been Inserted";
                DB.Employes.Add(e);
                DB.SaveChanges();
            }
            else
            {
                Message = "Data has been Updated";
                DB.Entry(e).State = EntityState.Modified;
                DB.SaveChanges();
            }
            return Json(new { Success = true, Message = Message }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult EditEmploye(int employeId)
        {
            return Json(DB.Employes.SingleOrDefault(model => model.Id == employeId), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DeleteEmploye(int employeId)
        {
            Employe emp = DB.Employes.Single(model => model.Id == employeId);
            DB.Employes.Remove(emp);
            DB.SaveChanges();
            return Json(new { Success = true, Message = "Data Sucessfully Deleted" }, JsonRequestBehavior.AllowGet);

        }
    }
}