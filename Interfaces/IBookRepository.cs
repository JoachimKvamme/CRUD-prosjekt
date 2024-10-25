using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_prosjekt.Models;

namespace CRUD_prosjekt.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync();
        Task<Book> CreateAsync();
        Task<Book?> UpdateAsync(int id, Book bookDto);
        Task<Book?> DeleteAsync(int id);
    }
}