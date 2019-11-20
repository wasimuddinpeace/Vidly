using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Models.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        public ApplicationDbContext _context { get; set; }

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Customers
        public ViewResult Index()
        {

            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            // ViewData["Movie"] = movie;//of type obect
            //ViewBag.Movie = movie;//added on run time no compile time safety with viewbag

            return View(customers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid) {

                var newviewmodel = new NewCustomerViewModel {

                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                    
                };
                return View("New", newviewmodel);
            }
                

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);

            }
            else

            {
                var customerIndb = _context.Customers.Single(c => c.Id == customer.Id);
                customerIndb.Name = customer.Name;
                customerIndb.Birthdate = customer.Birthdate;
                customerIndb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                customerIndb.MembershipTypeId = customer.MembershipTypeId;

            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);

        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);


            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewmodel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()

            };
            return View("New", viewmodel);
        }
        public ActionResult New()
        {
            var membershiptypes = _context.MembershipTypes.ToList();
            var viewmodel = new NewCustomerViewModel
            {
               Customer = new Customer(),
                MembershipTypes = membershiptypes
            };

            return View(viewmodel);
        }
    }
}