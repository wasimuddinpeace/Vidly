using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class GeosForProd
    {  
        [Key]
        public int Id { get; set; }
        public string GeoName { get; set; }
        // Foreign key   
        [Display(Name = "Environment")] //table 
        public virtual int EnvironmentId { get; set; }

        [ForeignKey("EnvironmentId")] //
        public virtual Environment Environments { get; set; }
        
    }
}