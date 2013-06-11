using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DavidMVC.Common;
using DavidMVC.Models;
using DavidMVC.Logic;

namespace DavidMVC.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult ViewTest(string id)
        {
            ViewData["id"] = "view_id";
            TempData["test"] = "temp_test";
            //return RedirectToAction("TestRedirect", "DavidTest");
            return View();
        }

        public ActionResult TestRedirect()
        { 
            return View();
        }

        public JsonResult GetTestData()
        {
            var testModelLs = new DavidBusinessLogic().GetJsonSerializeData();
            return Json(new { Data = JsonHelper.JsonSerializer<List<TestModel>>(testModelLs) }, JsonRequestBehavior.AllowGet);
        }
    }
}
