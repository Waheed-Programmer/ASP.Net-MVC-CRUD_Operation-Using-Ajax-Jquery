using System.Web;
using System.Web.Mvc;

namespace CRUD_Asp_MVC__JQuery_Ajax_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
