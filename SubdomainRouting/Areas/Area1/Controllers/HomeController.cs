using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SubdomainRouting.Areas.Area1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Area1/Home/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Action2()
        {
            return View("Action2");
        }

        public ActionResult RedirectToAction2()
        {
            return RedirectToAction("Action2");
        }
	}
}