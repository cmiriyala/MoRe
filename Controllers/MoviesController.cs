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
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);

            }
            else
            {
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Movies");
        }
        public ActionResult Edit(int id)
        {
            return Content("id="+id);
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