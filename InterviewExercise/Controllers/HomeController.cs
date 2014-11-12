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
        [OutputCache(Duration = 30)]
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        [OutputCache(Duration = 30)]
        public ActionResult GetEventsList(DataTableParamModel param)
        {
            List<Event> allRows = new List<Event>();
            List<Event> filteredRows = new List<Event>();

            for (int i = 1; i <= 10000; i++)
            {
                allRows.Add(new Event() { EventId = i, Title = "an event " + i, Technology = "a technology " + i, StartingDate = DateTime.Now, RegistrationLink = "a link " + i });
            }

            if (!string.IsNullOrEmpty(param.sSearch))
            {
                filteredRows = allRows.Where(e => e.Title.Contains(param.sSearch) || e.Technology.Contains(param.sSearch) || e.RegistrationLink.Contains(param.sSearch)).ToList();
            }
            else
            {
                filteredRows = allRows;
            }

            var displayedRows = filteredRows.Skip(param.iDisplayStart).Take(param.iDisplayLength);

            var result = from e in displayedRows
                         select new string[] { Convert.ToString(e.EventId), e.Title, e.Technology, e.StartingDate.ToShortDateString(), e.RegistrationLink };
            result = result.ToList();

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = allRows.Count(),
                iTotalDisplayRecords = filteredRows.Count(),
                aaData = result
            },
            JsonRequestBehavior.AllowGet);
        }
    }
}
