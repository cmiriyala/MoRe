using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoRe.ViewModels;
using MoRe.Models;

namespace MoRe.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = new List<Customer>
            {
                new Customer{Id=1,Name = "Chethan"},
                new Customer{Id=2,Name="Miriyala"}
            };
            var viewModel = new RandomMovieViewModel
            {
             
                Customers = customers
            };
            return View(viewModel);
            
        }
        public ActionResult View(int id, string name)
        {
            ViewBag.namecustomer = name;
            return View();
        }
    }
}