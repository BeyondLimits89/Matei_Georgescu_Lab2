﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using Matei_Georgescu_Lab2.Data;
using Matei_Georgescu_Lab2.Models;
using System.ComponentModel.DataAnnotations;

namespace Matei_Georgescu_Lab2.Models
{
	public class Borrowing
	{
		public int ID { get; set; }
		public int? MemberID { get; set; }
		public Member? Member { get; set; }
		public int? BookID { get; set; }
		public Book? Book { get; set; }
		[DataType(DataType.Date)]
		public DateTime ReturnDate { get; set; }
	}
}
