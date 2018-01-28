using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagement2.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [DisplayName("ISBN")]
        [RegularExpression("^([0-9]{10,13})$", ErrorMessage = "ISBN number only includes 10-13 digits")]
        [Required(ErrorMessage = "ISBN number is required")]
        public string ISBNNumber { get; set; }

        [DisplayName("Title")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Title is not valid")]
        [Required(ErrorMessage = "A title is required")]
        public string title { get; set; }

        [DisplayName("Author")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Author name is not valid")]
        [Required(ErrorMessage = "An author name is required")]
        public string author { get; set; }

        [DisplayName("Status")]
        public Boolean status { get; set; }

        [DisplayName("Upload file")]
        public string photo { get; set; }

        public int categoryID { get; set; }
        public int? borrowID { get; set; }

        [ForeignKey("categoryID")]
        public virtual Category category { get; set; }

        [ForeignKey("borrowID")]
        public virtual Borrow borrow { get; set; }
    }
}