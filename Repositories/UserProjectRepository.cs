using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_prosjekt.Data;
using CRUD_prosjekt.Interfaces;
using CRUD_prosjekt.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_prosjekt.Repositories
{
    public class UserProjectRepository : IUserProjectRepository
    {
        private readonly ApplicationDbContext _context;
        public UserProjectRepository(ApplicationDbContext context)
        {
            _context = context;            
        }

        public async Task<List<UserProject>> GetAllProjects()
        {
            return await _context.UserProjects.ToListAsync();
        }

        public async Task<List<Book>> GetUserProjects(int id)
        {
            return await _context.UserProjects.Where(u => u.ProjectId == id)
                .Select(book => new Book
                {
                    Id = book.BookId,
                    Title = book.Book.Title,
                    FirstNameAuthor = book.Book.FirstNameAuthor,
                    LastNameAuthor = book.Book.LastNameAuthor,
                    Year = book.Book.Year,
                    Place = book.Book.Place,
                    Publisher = book.Book.Publisher
                }).ToListAsync();
        }

    }
}