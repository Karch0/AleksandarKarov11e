using AleksandarKarov11e.Data.Models;
using AleksandarKarov11e.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AleksandarKarov11e.Controller
{
	public class GenreController
	{
		private readonly LibraryDbContext _context;

		public GenreController(LibraryDbContext context)
		{
			_context = context;
		}

		public void AddGenre(Genre genre)
		{
			if (genre == null)
			{
				throw new ArgumentNullException(nameof(genre), "Genre cannot be null.");
			}

			_context.Genres.Add(genre);
			_context.SaveChanges();
		}

		public List<Genre> GetAllGenres()
		{
			return _context.Genres.ToList();
		}

		public Genre GetGenreById(int id)
		{
			return _context.Genres.FirstOrDefault(g => g.Id == id);
		}

		public void UpdateGenre(Genre genre)
		{
			if (genre == null)
			{
				throw new ArgumentNullException(nameof(genre), "Genre cannot be null.");
			}

			var existingGenre = _context.Genres.FirstOrDefault(g => g.Id == genre.Id);
			if (existingGenre == null)
			{
				throw new InvalidOperationException($"Genre with ID {genre.Id} not found.");
			}

			existingGenre.Name = genre.Name;

			_context.SaveChanges();
		}

		public void DeleteGenre(int id)
		{
			var genre = _context.Genres.FirstOrDefault(g => g.Id == id);
			if (genre == null)
			{
				throw new InvalidOperationException($"Genre with ID {id} not found.");
			}

			_context.Genres.Remove(genre);
			_context.SaveChanges();
		}
	}
}
