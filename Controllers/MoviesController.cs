using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoRe.Models;
using MoRe.ViewModels;

namespace MoRe.Controllers
{
    public class MoviesController : Controller
    {
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
            var movies = new List<Movie>
            {
                new Movie{Id=1,Name = "Shrek!"},
                new Movie{Id=2,Name="Wall E!"}
            };
            var viewModel = new RandomMovieViewModel
            {
                Movies = movies
               
            };

            return View(viewModel);
        }
        public ActionResult View(int id, string name)
        {
            ViewBag.namemovie = name;
            return View();
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