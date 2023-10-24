using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Matei_Georgescu_Lab2.Models
{
    public class Book
    {
        public int ID { get; set; }
        
        public int? AuthorID { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }

        public Author? Author { get; set; }

        [Display(Name = "Book Title")]
		public string Title { get; set; }

		[Column(TypeName = "decimal(6, 2)")]
		public decimal Price { get; set; }

		[DataType(DataType.Date)]
        [Display(Name = "Publishing Date")]
        public DateTime PublishingDate { get; set; }

        public int? PublisherID { get; set; }

        [Display(Name = "Publisher Name")]
        public Publisher? Publisher { get; set; }
    }
}
