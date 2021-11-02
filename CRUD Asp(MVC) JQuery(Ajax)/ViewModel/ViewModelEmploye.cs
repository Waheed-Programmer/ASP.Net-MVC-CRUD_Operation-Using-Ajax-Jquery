using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Asp_MVC__JQuery_Ajax_.ViewModel
{
    public class ViewModelEmploye
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Nullable<int> Age { get; set; }
    }
}