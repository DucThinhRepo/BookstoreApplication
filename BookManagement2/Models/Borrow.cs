using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagement2.Models
{
    public class Borrow
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required(ErrorMessage ="Borrow date is required")]
        public DateTime borrow { get; set; }

        public DateTime retur { get; set; }

        [Required(ErrorMessage = "Dead line is required")]
        public DateTime deadline { get; set; }

        public int fine { get; set; }

        public int studentID { get; set; }

        [ForeignKey("studentID")]
        public virtual Student student { get; set; }
    }
}