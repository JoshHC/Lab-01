using System.Web;
using System.Web.Mvc;

namespace Lab01_1104017_1169317
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
