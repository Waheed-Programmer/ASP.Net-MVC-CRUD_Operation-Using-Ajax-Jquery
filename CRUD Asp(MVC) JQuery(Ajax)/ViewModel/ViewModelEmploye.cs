using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Asp_MVC__JQuery_Ajax_.ViewModel
{
    public class ViewModelEmploye
    {
        public int EmoloyeId { get; set; }
        public string Name { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<int> CityId { get; set; }
    }
}