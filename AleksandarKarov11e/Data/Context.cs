using AleksandarKarov11e.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AleksandarKarov11e.Data
{
	public class LibraryDbContext : DbContext
	{
		public DbSet<Reader> Readers { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<Genre> Genres { get; set; }

		public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
		{
		}

		public LibraryDbContext()
		{
		}	

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=212-1\\SQLEXPRESS; Database=LibraryTest123; Trusted_Connection=True; Encrypt=yes; TrustServerCertificate=Yes");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Reader>()
				.HasMany(r => r.BorrowedBooks)
				.WithMany(b => b.Readers)
				.UsingEntity(j => j.ToTable("ReaderBooks"));

			modelBuilder.Entity<Book>()
				.HasMany(b => b.Genres)
				.WithMany(g => g.Books)
				.UsingEntity(j => j.ToTable("BookGenres"));

			modelBuilder.Entity<Reader>()
				.Property(r => r.FirstName)
				.IsRequired()
				.HasMaxLength(50);

			modelBuilder.Entity<Reader>()
				.Property(r => r.LastName)
				.IsRequired()
				.HasMaxLength(50);

			modelBuilder.Entity<Reader>()
				.Property(r => r.Age)
				.IsRequired();

			modelBuilder.Entity<Reader>()
				.Property(r => r.Email)
				.IsRequired()
				.HasMaxLength(20);

			modelBuilder.Entity<Reader>()
				.Property(r => r.Phone)
				.IsRequired()
				.HasMaxLength(10);

			modelBuilder.Entity<Book>()
				.Property(b => b.Title)
				.IsRequired()
				.HasMaxLength(50);

			modelBuilder.Entity<Book>()
				.Property(b => b.Author)
				.HasMaxLength(50);

			modelBuilder.Entity<Genre>()
				.Property(g => g.Name)
				.IsRequired()
				.HasMaxLength(20);
		}
	}
}
