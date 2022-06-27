using System.ComponentModel.DataAnnotations;

namespace Mvcproject.Models
{
    public class Product
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Name{ get; set; }
        public decimal Price{ get; set; }

        

    }
}
