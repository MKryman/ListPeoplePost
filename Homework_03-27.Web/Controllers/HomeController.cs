using Homework_03_27.Data;
using Homework_03_27.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Homework_03_27.Web.Controllers
{
    public class HomeController : Controller
    {
        private string conStr = @"Data Source=.\sqlexpress;Initial Catalog= Cars_Games_People; Integrated Security=true";
        public IActionResult Index()
        {
            PersonData personDb = new(conStr);
            PersonViewModel vm = new PersonViewModel
            {
                People = personDb.GetAllPeople()
            };
            return View(vm);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(List<Person> people)
        {
            PersonData personDb = new(conStr);
            personDb.AddPeople(people);
            return Redirect("/");
        }

    }
}