using System.ComponentModel.DataAnnotations;

namespace mvcdemo.Models
{
    public class Student
    {
        [Key]
        [ScaffoldColumn(false)]
        public int RollNo { get; set; }
        [Display(Name ="Student Name")]
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Age is required")]
        [Range(minimum:10,maximum:60,ErrorMessage ="Age is between 10to60")]
        public int Age{ get; set; }
        [Required(ErrorMessage ="Emailid is required")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Emailid is not in proper format")]
        public string EmailId{ get; set; }
        [Required(ErrorMessage ="city is required")]
        [MaxLength(20)]
        public string City { get; set; }
        [Required(ErrorMessage ="password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
