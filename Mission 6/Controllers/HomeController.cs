using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission_6.Models;

namespace Mission_6.Controllers
{
    public class HomeController : Controller
    {

        private MovieContext _Context;
        // Constructor to initialize the database context
        public HomeController(MovieContext temp) 
        {
            _Context = temp;
        }

        //returns to homepage
        public IActionResult Index()
        {
            return View();
        }

        //returns to get to know you page
        public IActionResult GetToKnow()
        {
            return View();
        }

        // GET: Displays the movie form with category selection
        [HttpGet]
        public IActionResult Movie()
        {
            // Passes category list to the view for dropdown selection
            ViewBag.Categories = _Context.Categories
                .OrderBy(x => x.CategoryName) // Orders categories alphabetically
                .ToList();
            return View();
        }

        // POST: Adds a new movie entry to the database
        [HttpPost]
        public IActionResult Movie(Movie response)
        {
            _Context.Movies.Add(response); // Adds new movie
            _Context.SaveChanges(); // Saves changes
            return View("Confirmation", response); // Redirects to confirmation page
        }

        // Displays the list of movies
        public IActionResult MovieList()
        {
            var movieList = _Context.Movies
                .Include(x => x.Category) // Includes category details
                .OrderBy(x => x.Title).ToList(); // Orders movies alphabetically by title

            return View(movieList);
        }

        // GET: Loads movie data into the form for editing
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _Context.Movies
                .Single(x => x.MovieId == id); // Fetches movie by ID

            // Passes category list to the view for dropdown selection
            ViewBag.Categories = _Context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View("Movie", recordToEdit); // Uses the same form as the add movie view
        }

        // POST: Updates an existing movie record
        [HttpPost]
        public IActionResult Edit(Movie updatedMovie)
        {
            _Context.Update(updatedMovie); // Updates movie entry
            _Context.SaveChanges(); // Saves changes
            return RedirectToAction("MovieList"); // Redirects back to movie list
        }

        // GET: Loads the delete confirmation page for a specific movie
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _Context.Movies
                .Single(x => x.MovieId == id); // Fetches movie by ID
            return View(recordToDelete); // Loads the delete confirmation view

        }

        // POST: Deletes the selected movie from the database
        [HttpPost]
        public IActionResult Delete(Movie deleteMovie)
        {
            _Context.Movies.Remove(deleteMovie); // Removes movie entry
            _Context.SaveChanges(); // Saves changes
            return RedirectToAction("MovieList"); // Redirects back to movie list
        }
    }
}
