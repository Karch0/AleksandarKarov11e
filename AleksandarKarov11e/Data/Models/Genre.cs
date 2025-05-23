﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AleksandarKarov11e.Data.Models
{
	public class Genre
	{
		[Key]
		public int Id { get; set; }

		[Required, MaxLength(20)]
		public string Name { get; set; }

		public List<Book> Books { get; set; }
	}
}
