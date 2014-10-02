using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AnswersTest.Helpers;
using AnswersTest.Model;
using AnswersTest.Services;

namespace AnswersTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataService DataService = new DataService();
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoadAll()
        {
            var people = DataService.LoadPeople();
            return GetJson(people);
        }

        [HttpGet]
        public ActionResult LoadPerson(int id)
        {
            var person = DataService.LoadPerson(id);
            var colors = DataService.LoadColours();
            return GetJson(new { Person = person, AvailableColors = colors });
        }

        [HttpPost]
        public ActionResult UpdatePerson(PersonData data)
        {
            DataService.UpdatePerson(data);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        private JsonCamelCaseResult GetJson(object data)
        {
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }
    }
}