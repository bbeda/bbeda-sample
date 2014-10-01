using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnswersTest.Helpers;
using AnswersTest.Services;

namespace AnswersTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataService DataService = new DataService();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoadAll()
        {
            var people = DataService.LoadPeople();
            return new JsonCamelCaseResult(people, JsonRequestBehavior.AllowGet);
        }
    }
}