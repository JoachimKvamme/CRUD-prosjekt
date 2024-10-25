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
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;
        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<Project> CreateAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Project?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Project>> GetAllAsync()
        {
            var projects = _context.Projects.Include(b => b.Books);
            return await projects.ToListAsync();
        }

        public Task<Project?> GetByIdAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Project?> UpdateAsync(int id, Project projectDto)
        {
            throw new NotImplementedException();
        }
    }
}