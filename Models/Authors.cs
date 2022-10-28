using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Selin_Robert_Cristian_Lab2.Models
{
    public class Authors
    {
        public int ID { get; set; } 
        public string FirstName { get; set; }

        [Display(Name = "Author Last Name")]
        public string LastName { get; set; }
        public ICollection<Book>? Books { get; set; } // navigation property
    }
}
