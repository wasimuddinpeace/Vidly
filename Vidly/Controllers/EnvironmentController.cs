using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Models.ViewModels;

namespace Vidly.Controllers
{
    public class EnvironmentController : Controller
    {
        public ApplicationDbContext _context { get; set; }

        public EnvironmentController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Environment
        public ActionResult Index()
        {
            var _Environments = _context.EnvironmentType.ToList();

            var viewmodel = new EnvironmentViewModel
            {
                Environment = new Models.Environment(),
                Environments = _Environments

            };
            // ViewData["Movie"] = movie;//of type obect
            //ViewBag.Movie = movie;//added on run time no compile time safety with viewbag

            return View(viewmodel);
        }
        public ActionResult GetGeos(int EnvironmentId)
        {
            var geos = _context.GeosForProd.Where(g => g.Id == EnvironmentId).ToList();
  
            return View();
        }
    }
}