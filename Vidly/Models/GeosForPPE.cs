using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class GeosForPPE
    {   
        [Key]
        public int Id { get; set; }
        public string GeoName { get; set; }  
    }
}