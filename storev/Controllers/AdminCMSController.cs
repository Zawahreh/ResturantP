using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace storev.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminCMSController : Controller
    {
        // GET: AdminCMS
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddMeal()
        {
            return View();
        }
        public ActionResult EditMeal(int id)
        {
            ViewData["id"] = id;
            return View();
        }

        public ActionResult FindBill(int id)
        {
            ViewData["BillId"] = id;
            return View();
        }
    }
}