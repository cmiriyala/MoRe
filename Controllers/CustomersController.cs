using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoRe.ViewModels;
using MoRe.Models;
using System.Data.Entity;

namespace MoRe.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c=>c.MembershipType).ToList();
            var viewModel = new CustomerFormViewModel
            {
             
                Customers = customers
            };
            return View(viewModel);
            
        }
        public ActionResult View(int id)
        {
            var customerdata = _context.Customers.Include(c => c.MembershipType).Single(c=> c.Id == id);
            if(customerdata == null)
                return HttpNotFound();
            
            ViewBag.namecustomer = customerdata.Name;
            ViewBag.customerMembershitype= customerdata.MembershipType.Name;
            if (customerdata.Birthdate != null)
            {
                ViewBag.birthdate = customerdata.Birthdate;
            }
            else if (customerdata.Birthdate == null)
            { 
                ViewBag.birthdate = "nobirthdate";
            }
            return View();
        }
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();    
            var viewModelcustomerMembershiptype = new CustomerFormViewModel 
            {

                MembershipTypes = membershipTypes

            };
            return View(viewModelcustomerMembershiptype);
        }
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
                
            }
            else
            {
                var customerInDb = _context.Customers.SingleOrDefault(C => C.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipType = customer.MembershipType;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            }
            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()

            };
            return View("New", viewModel);
        }
    }
}