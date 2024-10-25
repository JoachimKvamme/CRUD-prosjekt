using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_prosjekt.Data;
using CRUD_prosjekt.Interfaces;
using CRUD_prosjekt.Models;

namespace CRUD_prosjekt.Repositories
{
    public class BookRepository : IBookRepository
    {

        private readonly ApplicationDbContext _context;
        public BookRepository(Parameters)
        {
            
        }
        public Task<Book> CreateAsync(Book bookModel)
        {
            throw new NotImplementedException();
        }

        public Task<Book?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Book?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Book?> UpdateAsync(int id, Book bookDto)
        {
            throw new NotImplementedException();
        }
    }
}