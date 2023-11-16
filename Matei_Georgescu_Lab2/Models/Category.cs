using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Matei_Georgescu_Lab2.Models
{
	public class Category
	{  
		public int ID { get; set; }

		[Display(Name = "Category")]
		public string CategoryName { get; set; }
		public ICollection<BookCategory>? BookCategories { get; set; }
	}
}
