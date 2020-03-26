using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppCore.WebSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ciudades()
        {
            ViewBag.Message = "Listado de Ciudades";

            return View();
        }

        public ActionResult Vendedores()
        {
            ViewBag.Message = "Listado de Vendedores.";

            return View();
        }
    }
}