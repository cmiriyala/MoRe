using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoRe.Models;
using MoRe.ViewModels;
using System.Data.Entity;


namespace MoRe.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies/Random
        /* public ActionResult Random()
         {
             var movie = new Movie() { Name = "Shrek!" };
             var customers = new List<Customer>
             {
                 new Customer{Name = "Chethan"},
                 new Customer{Name="Miriyala"}
             };
             var viewModel = new RandomMovieViewModel
             {
                 Movie = movie,
                 Customers = customers
             };
             return View(viewModel);
         }
         */
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genres).ToList();
                
            var viewModel = new CustomerFormViewModel
            {
                Movies = movies
               
            };

            return View(viewModel);
        }
        public ActionResult View(int id)
        {
            var moviedata = _context.Movies.Include(m => m.Genres).Single(m => m.Id == id);
            if (moviedata == null)
                return HttpNotFound();
            ViewBag.namemovie = moviedata.Name;
            ViewBag.movieGenre = moviedata.Genres.Name;
            ViewBag.movieReleaseDate = moviedata.ReleaseDate;
            ViewBag.movieAddedDate = moviedata.AddedDate;
            ViewBag.movieinstock = moviedata.NumberinStock;


            return View();
        }
        public ActionResult NewMovie()

        {
            ViewBag.TitleMovie = "New Movie";
            var generlist = _context.Genres.ToList();
            var ViewModel = new CustomerFormViewModel
            {
                Genres = generlist
            };
                
            return View(ViewModel);
        }
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (ModelState.IsValid)
            {
                var ViewModel = new CustomerFormViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View("NewMovie", ViewModel);
            }
            if (movie.Id == 0)
            {
                movie.AddedDate = DateTime.Now;
                _context.Movies.Add(movie);

            }
            else
            {
                var movieInDB = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDB.Name = movie.Name;
                movieInDB.GenresId = movie.GenresId;
                movieInDB.NumberinStock = movie.NumberinStock;
                movieInDB.ReleaseDate = movie.ReleaseDate;

            }
            _context.SaveChanges();
            return RedirectToAction("Index","Movies");
        }
        public ActionResult Edit(int id)
        {
            ViewBag.TitleMovie = "Edit Movie";
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if( movie== null)
            {
                return HttpNotFound();
            }

            var ViewModel = new CustomerFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("NewMovie", ViewModel);
        }
      /* public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        } */
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year+"/" + month);
        }
    }
}