using AleksandarKarov11e.Data;
using AleksandarKarov11e.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AleksandarKarov11e.Controller
{
	public class ReaderController
	{
		private readonly LibraryDbContext _context;

		public ReaderController(LibraryDbContext context)
		{
			_context = context;
		}

		public void AddReader(Reader reader)
		{
			if (reader == null)
			{
				throw new ArgumentNullException(nameof(reader), "Reader cannot be null.");
			}

			_context.Readers.Add(reader);
			_context.SaveChanges();
		}

		public List<Reader> GetAllReaders()
		{
			return _context.Readers.ToList();
		}

		public Reader GetReaderById(int id)
		{
			return _context.Readers.FirstOrDefault(r => r.Id == id);
		}

		public void UpdateReader(Reader reader)
		{
			if (reader == null)
			{
				throw new ArgumentNullException(nameof(reader), "Reader cannot be null.");
			}

			var existingReader = _context.Readers.FirstOrDefault(r => r.Id == reader.Id);
			if (existingReader == null)
			{
				throw new InvalidOperationException($"Reader with ID {reader.Id} not found.");
			}

			existingReader.FirstName = reader.FirstName;
			existingReader.LastName = reader.LastName;
			existingReader.Age = reader.Age;
			existingReader.Email = reader.Email;
			existingReader.Phone = reader.Phone;

			_context.SaveChanges();
		}

		public void DeleteReader(int id)
		{
			var reader = _context.Readers.FirstOrDefault(r => r.Id == id);
			if (reader == null)
			{
				throw new InvalidOperationException($"Reader with ID {id} not found.");
			}

			_context.Readers.Remove(reader);
			_context.SaveChanges();
		}
	}
}
