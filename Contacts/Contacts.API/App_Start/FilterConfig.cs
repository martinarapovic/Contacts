using System.Web;
using System.Web.Mvc;
using Contacts.API.Filters;

namespace Contacts.API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
