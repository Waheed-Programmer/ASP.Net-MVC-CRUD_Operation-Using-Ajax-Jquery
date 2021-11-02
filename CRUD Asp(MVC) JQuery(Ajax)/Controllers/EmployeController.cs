using CRUD_Asp_MVC__JQuery_Ajax_.Models;
using CRUD_Asp_MVC__JQuery_Ajax_.ViewModel;
using System;
using System.Collections.Generic;
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
            var employe = DB.Employes.ToList();
            return Json(new { Success = true, data = employe }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddUpdateEmploye(ViewModelEmploye view)
        {
            string Message = "Data has been updated";
            Employe e = new Employe();
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
            return Json(new { Success = true, Message = Message }, JsonRequestBehavior.AllowGet);
        }
    }
}