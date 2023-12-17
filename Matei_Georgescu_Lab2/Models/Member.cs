using System.ComponentModel.DataAnnotations;

namespace Matei_Georgescu_Lab2.Models
{
	public class Member
	{
		public int ID { get; set; }


		[RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "First name should start with a capital letter")]
		[StringLength(30, MinimumLength = 3)]
		public string? FirstName { get; set; }

		[RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Last name should start with a capital letter")]
		[StringLength(30, MinimumLength = 3)]
		public string? LastName { get; set; }
		
		[StringLength(70)]
		public string? Address { get; set; }
		public string Email { get; set; }

		[RegularExpression(@"^0[0-9]{3}[-. ]?[0-9]{3}[-. ]?[0-9]{3}$", ErrorMessage = "Phone number must be in the format '0722-123-123', '0722.123.123', or '0722 123 123'")]
		public string? Phone { get; set; }

		[Display(Name = "Full Name")]
		public string? FullName
		{
			get
			{
				return FirstName + " " + LastName;
			}
		}
		public ICollection<Borrowing>? Borrowings { get; set; }
	}
}

