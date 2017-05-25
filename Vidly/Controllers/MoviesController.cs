using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels; 

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context; 
        // GET: Movies/Random

        public MoviesController ()
        {
            _context = new ApplicationDbContext(); 
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shreak!" };

            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            }; 
            //return HttpNotFound(); 
            //return Content("Hello World");
            
            //Dictionary - Access array through enumerated variables/names rather than integer values 
            //ViewData["Movie"] = movie; 
            return View(viewModel);

            //return new EmptyResult(); 
           // return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name"});
        } 

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate (int? year, int? month)
        {
            return Content(year + "/" + month);
        }

        // movies
        // ? before variable declaration allows empty/null values so you can test 
        //for HasValue 
        /*
        public ActionResult Index (int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
        */
        //[Route("Movies")]
        public ActionResult Index ()
        {
            /*
            var movielist = new List<Movie> {
                new Movie {Name = "Shrek!"},
                new Movie {Name = "Wall-e"}
            };

            var viewmodel = new RandomMovieViewModel
            {
                Movies = movielist
            }; */

            //var movies = _context.Movies.Include(g => g.Genre).ToList();
            var movies = _context.Movies.Include(g => g.Genre).ToList();

            //return View(movies);
            return View(movies); 
        }

        public ActionResult Details (int id)
        {
            var movie = _context
                        .Movies
                        .Include(g => g.Genre)
                        .SingleOrDefault(m => m.id == id);
            if(movie == null)
            {
                return HttpNotFound();
            }

            return View(movie); 
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Name = "Shreak", id = 1},
                new Movie { Name = "Wall-E", id = 2}
            }; 
        }
    }
}