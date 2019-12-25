using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Models.ViewModels
{
    public class EnvironmentViewModel
    {
        public IEnumerable<Environment> Environments { get; set; }
        public Environment Environment { get; set; }
    }
}