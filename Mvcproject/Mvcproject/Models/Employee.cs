using System.ComponentModel.DataAnnotations;

namespace Mvcproject.Models
{
    public class Employee
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }

    }
}
