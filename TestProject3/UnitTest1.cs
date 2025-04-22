namespace TestProject1
{
	using AleksandarKarov11e.Controller;
	using AleksandarKarov11e.Data.Models;
	using AleksandarKarov11e.Data;
	using Microsoft.EntityFrameworkCore;
	using NUnit.Framework;

	[TestFixture]
	public class GenreControllerTests
	{
		private LibraryDbContext _context;
		private GenreController _genreController;

		[SetUp]
		public void Setup()
		{
			var options = new DbContextOptionsBuilder<LibraryDbContext>()
				.UseInMemoryDatabase(databaseName: "TestLibraryDb")
				.Options;

			_context = new LibraryDbContext(options);

			_context.Database.EnsureDeleted();
			_context.Database.EnsureCreated();

			_genreController = new GenreController(_context);
		}

		[TearDown]
		public void TearDown()
		{
			_context.Dispose();
		}

		[Test]
		public void AddGenre_ShouldAddGenreToDatabase()
		{
			var genre = new Genre { Name = "Science Fiction" };

			_genreController.AddGenre(genre);

			var genres = _context.Genres.ToList();
			Assert.That(genres.Count, Is.EqualTo(1));
			Assert.That(genres[0].Name, Is.EqualTo("Science Fiction"));
		}

		[Test]
		public void GetAllGenres_ShouldReturnAllGenres()
		{
			_context.Genres.Add(new Genre { Name = "Fantasy" });
			_context.Genres.Add(new Genre { Name = "Horror" });
			_context.SaveChanges();

			var genres = _genreController.GetAllGenres();

			Assert.That(genres.Count, Is.EqualTo(2));
			Assert.That(genres.Any(g => g.Name == "Fantasy"), Is.True);
			Assert.That(genres.Any(g => g.Name == "Horror"), Is.True);
		}

		[Test]
		public void GetGenreById_ShouldReturnCorrectGenre()
		{
			var genre = new Genre { Name = "Mystery" };
			_context.Genres.Add(genre);
			_context.SaveChanges();

			var result = _genreController.GetGenreById(genre.Id);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Name, Is.EqualTo("Mystery"));
		}

		[Test]
		public void UpdateGenre_ShouldUpdateGenreInDatabase()
		{
			var genre = new Genre { Name = "Adventure" };
			_context.Genres.Add(genre);
			_context.SaveChanges();

			genre.Name = "Action Adventure";
			_genreController.UpdateGenre(genre);

			var updatedGenre = _context.Genres.FirstOrDefault(g => g.Id == genre.Id);
			Assert.That(updatedGenre, Is.Not.Null);
			Assert.That(updatedGenre.Name, Is.EqualTo("Action Adventure"));
		}

		[Test]
		public void DeleteGenre_ShouldRemoveGenreFromDatabase()
		{
			var genre = new Genre { Name = "Romance" };
			_context.Genres.Add(genre);
			_context.SaveChanges();

			_genreController.DeleteGenre(genre.Id);

			var deletedGenre = _context.Genres.FirstOrDefault(g => g.Id == genre.Id);
			Assert.That(deletedGenre, Is.Null);
		}
	}
}
