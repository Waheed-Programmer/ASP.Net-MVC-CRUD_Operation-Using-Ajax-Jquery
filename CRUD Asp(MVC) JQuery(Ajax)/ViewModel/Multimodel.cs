using CRUD_Asp_MVC__JQuery_Ajax_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Asp_MVC__JQuery_Ajax_.ViewModel
{
    public class Multimodel
    {
        public List<EmployeTable> My_Employe { get; set; }
        public List<CityTable> City { get; set; }
    }
}