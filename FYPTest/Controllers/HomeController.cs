using FYPTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYPTest.Controllers
{
    public class HomeController : Controller
    {
        private msdb1740Entities db = new msdb1740Entities();
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
        public ActionResult Dropdown()
        {
            ViewBag.Message = "Your dropdown page.";

            return View(db.testDBs.ToList());
        }
        [HttpPost]
        public ActionResult Dropdown(string name)
        {
            var query = from a in db.testDBs
                        where a.Surname.Contains(name)
                        select a;
            var item = query.FirstOrDefault();
            if (item != null)
                return View(query.ToList());
            else
                return View("NotFound");  //Let's show a view about item not found
        }
    }
}