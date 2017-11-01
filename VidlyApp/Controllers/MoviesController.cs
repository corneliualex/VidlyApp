using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyApp.Models;
using VidlyApp.ViewModels;

namespace VidlyApp.Controllers
{
    public class MoviesController : Controller
    {

        //GET : movies/
        public ActionResult Index()
        {
            var movies = GetMovies();
            return View(movies);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>()
            {
                new Movie()
                {
                    Id=1,
                    Name="Shrek"
                },
                new Movie()
                {
                    Id=2,
                    Name="Spiderman"
                }
            };
        }
        /*// GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie()
            {
                Name = "Shrek"
            };

            var customers = new List<Customer>() {
                new Customer() {Name="Customer 1" },
                new Customer() {Name="Customer 2" }
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }
         //First code
         public ActionResult Random()
        {
            var movie = new Movie()
            {
                Name = "Shrek"
            };
            //Bad approach
            ViewData["Movie"] = movie; // Movie is magic string 
            //Bad approach
            ViewBag.Movie = movie; //Movie is magic property added to the Movie at runtime and we don't get compile time safety
            //Best approach
            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public ActionResult Index(int? id, string sortBy)
        {
            return Content(String.Format("id={0}&sortBy={1}", id, sortBy));
        }

        //ASP .NET MVC Attribute Route Constraints for more info about regex
        [Route("movies/released/{year:regex(\\d{4}):range(1800,2020)}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int? year,int? month)
        {
            return Content(String.Format("year={0}&month={1}",year,month));
        }*/
    }
}