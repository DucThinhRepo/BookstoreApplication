using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagement2.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public string name { get; set; }

        public string address { get; set; }

        public string phone { get; set; }

        public int majorID { get; set; }

        [ForeignKey("majorID")]
        public virtual Major major { get; set; }
    }
}