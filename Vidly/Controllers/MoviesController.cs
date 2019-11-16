using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Models.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        public ActionResult Index()
        {
            var movie = new Movie()
            {
                Name = "Shrek!"
            };
            var customers = new List<Customer>
            {
               new Customer { Name="Sanu"},
               new Customer { Name="Washu"}
            };
            var movies = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers  
            };
            
            return View(movies);
        }
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() {
                Name = "Shrek!"};
            var customers = new List<Customer>
            {
               new Customer { Name="Sanu"},
               new Customer { Name="Washu"}
            };

            var viewModel = new Models.ViewModels.RandomMovieViewModel {
                Movie = movie,
                Customers = customers
            
            };

           // ViewData["Movie"] = movie;//of type obect
            //ViewBag.Movie = movie;//added on run time no compile time safety with viewbag
 
             return View(viewModel);//this is a view data dictionary
        }
        public ActionResult Edit(int id)
        {
            return Content("ID="+ id);
        }
        //optional parameter
        //public ActionResult Index(int? PageIndex, string sortBy)
        //{
        //    if (!PageIndex.HasValue)
        //        PageIndex = 1;
        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";
        //    return Content(string.Format("PageIndex={0} + sortby={1}",PageIndex,sortBy));
        //}
        
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, Byte month)
        {
            return Content(year+"/"+month);
        }
    }
}