using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission06_espilker.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_espilker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieContext movieContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieContext movieContext)
        {
            _logger = logger;
            this.movieContext = movieContext;
        }

        //Return the index page
        public IActionResult Index()
        {
            return View();
        }

        //Returns the Podcast page
        public IActionResult Podcast()
        {
            return View();
        }

        //Standard get for the movie page form
        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = movieContext.Categories.ToList();
            return View(new MovieModel());
        }

        //View for Posting the form of the Movie Form
        [HttpPost]
        public IActionResult MovieForm(MovieModel movieModel)
        {
            if (ModelState.IsValid)
             {
                movieContext.Add(movieModel);
                movieContext.SaveChanges();
                return View("Index", movieModel);
            }
            else 
            {
                ViewBag.Categories = movieContext.Categories.ToList();
                return View();
            }
        }

        //Action to ge the movietable
        [HttpGet]
        public IActionResult MovieTable()
        {
            // Create a movie database variable and pass it into the page
            var Moviedb = movieContext.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Director)
                .ToList();
            return View(Moviedb);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //gets the Edit html page
        [HttpGet]
        public IActionResult Edit (int id)
        {
            //passes in the categories table and the movie that the user has clicked on
            ViewBag.Categories = movieContext.Categories.ToList();
            var movie = movieContext.Movies.Single(x => x.MovieId == id);
            return View("MovieForm", movie);
        }

        //When user submits the edits, it saves the changes to the database
        [HttpPost]
        public IActionResult Edit(MovieModel movieModel)
        {
            movieContext.Update(movieModel);
            movieContext.SaveChanges();
            return RedirectToAction("MovieTable");
        }

        //Redirects the user to the delete page
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = movieContext.Movies.Single(x => x.MovieId == id);

            return View(movie);
        }

        //Post method to delete the selected movie from the database
        [HttpPost]
        public IActionResult Delete(MovieModel moviemodel)
        {
            movieContext.Movies.Remove(moviemodel);
            movieContext.SaveChanges();
            return RedirectToAction("MovieTable");
        }
    }
}
