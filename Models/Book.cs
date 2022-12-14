using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Selin_Robert_Cristian_Lab2.Models
{
    public class Book
    {
        public int ID { get; set; }

        [Display(Name = "Book Title")]
        public string Title { get; set; }
        //public string Author { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType (DataType.Date)]
        public DateTime PublishingDate { get; set; }

        public int? PublisherId { get; set; }

        public Publisher? Publisher { get; set; } // navigation property

        public int? AuthorsId { get; set; }

        public Authors? Authors { get; set; } // navigation property

    }
}
