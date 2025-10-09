using System.Web;
using System.Web.Mvc;

namespace SistemaVC_VinosCosteros
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
