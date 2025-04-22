using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AleksandarKarov11e.Data.Models
{
	public class Book
	{
		[Key]
		public int Id { get; set; }

		[Required, MaxLength(50)]
		public string Title { get; set; }

		[MaxLength(50)]
		public string Author { get; set; }

		public List<Reader> Readers { get; set; }
		public List<Genre> Genres { get; set; }

		public Book()
		{
			Readers = new List<Reader>();
			Genres = new List<Genre>();
		}
	}
}
