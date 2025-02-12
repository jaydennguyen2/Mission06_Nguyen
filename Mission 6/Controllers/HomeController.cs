using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission_6.Models;

namespace Mission_6.Controllers
{
    public class HomeController : Controller
    {

        private MovieContext _Context;
        public HomeController(MovieContext temp) 
        {
            _Context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnow()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Movie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Movie(Movie response)
        {
            _Context.Movies.Add(response);
            _Context.SaveChanges();
            return View("Confirmation", response);
        }


    }
}
