using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaVC_VinosCosteros.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult PaginaEnConstruccion()
        {
            // Puedes pasar un mensaje personalizado si quieres
            ViewBag.Mensaje = "Estamos trabajando en esta sección para ofrecerte la mejor experiencia.";
            return View();
        }

    }
}