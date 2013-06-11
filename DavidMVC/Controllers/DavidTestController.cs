using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using DavidMVC.Models;
using DavidMVC.Logic;
using DavidMVC.Common;

namespace DavidMVC.Controllers
{
    public class DavidTestController : Controller
    {
        //
        // GET: /DavidTest/

        private DavidBusinessLogic logic = new DavidBusinessLogic();

        public ActionResult TestRedirect()
        {
            return RedirectToAction("TestRedirect", "Home");
        }

        public ActionResult HighCharts()
        {
            return View();
        }

        public ActionResult NavigationPage()
        {
            return View();
        }

        #region 测试导航
        public ActionResult Level1Li()
        {
            return View();
        }

        public ActionResult Level2Li1()
        {
            return View();
        }

        public ActionResult Level2Li2()
        {
            return View();
        }

        public ActionResult Level3Li1()
        {
            return View();
        }

        public ActionResult Level3Li2()
        {
            return View();
        }

        public ActionResult Level3Li3()
        {
            return View();
        }

        public ActionResult Level3Li4()
        {
            return View();
        }

        public ActionResult Level3Li5()
        {
            return View();
        }

        public ActionResult Level3Li6()
        {
            return View();
        }

        public ActionResult Level4Li1()
        {
            return View();
        }

        public ActionResult Level4Li2()
        {
            return View();
        }

        public ActionResult Level2Li3()
        {
            return View();
        }

        public ActionResult Level3Li7()
        {
            return View();
        }

        public ActionResult Level3Li8()
        {
            return View();
        }

        public ActionResult Level3Li9()
        {
            return View();
        }

        public ActionResult Level3Li10()
        {
            return View();
        }

        public ActionResult Level3Li11()
        {
            return View();
        }

        public ActionResult Level2Li4()
        {
            return View();
        }

        public ActionResult Level3Li12()
        {
            return View();
        }

        public ActionResult Level3Li13()
        {
            return View();
        }

        public ActionResult Level3Li14()
        {
            return View();
        }

        public ActionResult Level3Li15()
        {
            return View();
        }

        public ActionResult Level3Li16()
        {
            return View();
        }

        public ActionResult Level1Li2()
        {
            return View();
        }

        public ActionResult Level2Li5()
        {
            return View();
        }
        #endregion
        

        public JsonResult GetHighChartOptions()
        {
            HighChartOptions chartOptions = logic.GetHighChartOptions();
            return Json(new { options = chartOptions }, JsonRequestBehavior.AllowGet);
        }
    }
}
