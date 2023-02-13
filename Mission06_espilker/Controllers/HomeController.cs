using Microsoft.AspNetCore.Mvc;
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
        private MovieContext _movieContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieContext movieContext)
        {
            _logger = logger;
            _movieContext = movieContext;
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
            return View();
        }

        //View for Posting the form of the Movie Form
        [HttpPost]
        public IActionResult MovieForm(MovieModel movieModel)
        {
            if (ModelState.IsValid)
             {
                _movieContext.Add(movieModel);
                _movieContext.SaveChanges();
                return View("Index", movieModel);
            }
            else {return View();}
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
