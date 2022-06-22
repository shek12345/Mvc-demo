using System;
using System.ComponentModel.DataAnnotations;

namespace mvcdemo.Models
{
    public class Book
    {

        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Display(Name = " Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Author Name is required")]
        [MaxLength(20)]
            public string AuthorName { get; set; }
            [Required(ErrorMessage = "Publisher Name is required")]
            [MaxLength(40)]
            public string PublisherName { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublisherDate { get; set; }

        [Required(ErrorMessage = " Book Price is required")]
        [Range(minimum:100,maximum:1000 ,ErrorMessage ="Price is between 100-1000")]

        public int Price { get; set; }

    }
    }


