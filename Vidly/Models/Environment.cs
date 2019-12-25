using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Environment
    {
        [DisplayName("Environment Name")]
        public string EnvironmentName { get; set; }
        [Key]
        public int EnvironmentId { get; set; }
        //public GeosForProd Id { get; set; }
        //public string PPE { get; set; }
        //public GeosForProd GeosForProd { get; set; }
        //public GeosForProdPrv GeosForProdPrv { get; set; }
        //public GeosForPPE GeosForPPE { get; set; }        
    }
}