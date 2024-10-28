using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_prosjekt.Data;
using CRUD_prosjekt.Dto.Book;
using CRUD_prosjekt.Interfaces;
using CRUD_prosjekt.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_prosjekt.Repositories
{
    public class BookRepository : IBookRepository
    {

        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Book> CreateAsync(Book bookModel)
        {
            await _context.Books.AddAsync(bookModel);
            await _context.SaveChangesAsync();
            return bookModel;
        }

        public async Task<Book?> DeleteAsync(int id)
        {
            var bookModel = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);

            if(bookModel == null) return null;

            _context.Books.Remove(bookModel);
            await _context.SaveChangesAsync();

            return bookModel;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Book?> UpdateAsync(int id, UpdateBookDto bookDto)
        {
            var existingBook = await _context.Books.FindAsync(id);

            if(existingBook == null) return null;

            existingBook.Title = bookDto.Title;
            existingBook.FirstNameAuthor = bookDto.FirstNameAuthor;
            existingBook.LastNameAuthor = bookDto.LastNameAuthor;
            existingBook.Year = bookDto.Year;
            existingBook.Publisher = bookDto.Publisher;
            existingBook.Place = bookDto.Place;

            await _context.SaveChangesAsync();
            
            return existingBook;
        }
    }
}