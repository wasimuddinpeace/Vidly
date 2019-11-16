using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var movie = new Movie()
            {
                Name = "Shrek!"
            };
            var customers = new List<Customer>
            {
                new Customer {Id=1, Name="Asim"},
               new Customer { Id=2 , Name="Waseem"},
                new Customer { Id=3, Name="Junaid"},
                 new Customer { Id=4, Name="Zubair"},
                  new Customer { Id=5, Name="Uzair"}
            };

            var viewModel = new Models.ViewModels.RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers

            };

            // ViewData["Movie"] = movie;//of type obect
            //ViewBag.Movie = movie;//added on run time no compile time safety with viewbag

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);

        }
        public IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
               new Customer {Id=1, Name="Asim"},
               new Customer { Id=2 , Name="Waseem"},
                new Customer { Id=3, Name="Junaid"},
                 new Customer { Id=4, Name="Zubair"},
                  new Customer { Id=5, Name="Uzair"}
            };
        }
    }
}