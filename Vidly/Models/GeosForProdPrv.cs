using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class GeosForProdPrv
    {
        [Key]
        public int Id { get; set; }
        public string GeoName { get; set; }
    }
}