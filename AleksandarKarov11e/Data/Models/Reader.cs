using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AleksandarKarov11e.Data.Models
{
	public class Reader
	{
		[Key]
		public int Id { get; set; }

		[Required, MaxLength(50)]
		public string FirstName { get; set; }

		[Required, MaxLength(50)]
		public string LastName { get; set; }

		[Required, Range(10, 80)]
		public int Age { get; set; }

		[Required, MaxLength(20)]
		public string Email { get; set; }

		[Required]
		[RegularExpression(@"^.{10}$", ErrorMessage = "Phone number must be exactly 10 digits long.")]
		public string Phone { get; set; }

		public List<Book> BorrowedBooks { get; set; }

		public Reader()
		{
			BorrowedBooks = new List<Book>();
		}
	}
}
