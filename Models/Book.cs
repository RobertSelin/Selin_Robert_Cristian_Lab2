using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Selin_Robert_Cristian_Lab2.Models
{
    public class Book
    {
        public int ID { get; set; }

        [Display(Name = "Book Title")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Titlul cartii trebuie sa aiba cel putin 3 caractaere")]
        public string Title { get; set; }
        //public string Author { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 500)]
        public decimal Price { get; set; }

        [DataType (DataType.Date)]
        public DateTime PublishingDate { get; set; }

        public int? PublisherId { get; set; }

        public Publisher? Publisher { get; set; } // navigation property

        public int? AuthorsId { get; set; }

        public Authors? Authors { get; set; } // navigation property

        public ICollection<BookCategory>? BookCategories { get; set; }
    }
}
