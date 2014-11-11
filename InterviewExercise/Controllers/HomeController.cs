using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InterviewExercise.Models;

namespace InterviewExercise.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        [OutputCache(CacheProfile = "Long")]
        public ActionResult GetEventsList(DataTableParamModel param)
        {
            List<string[]> rowsToReturn = new List<string[]>();

            for (int i = 1; i <= 10000; i++)
            {
                rowsToReturn.Add(new string[] {i.ToString(), "an event " + i, "a technology " + i, DateTime.Now.ToString(), "a link " + i});                    
            }

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = 34,
                iTotalDisplayRecords = 4,
                aaData = rowsToReturn
            },
            JsonRequestBehavior.AllowGet);
        }
    }
}
