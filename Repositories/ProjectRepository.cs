using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_prosjekt.Data;
using CRUD_prosjekt.Dto.Project;
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
        public async Task<Project> CreateAsync(Project projectModel)
        {
            await _context.Projects.AddAsync(projectModel);
            await _context.SaveChangesAsync();
            return projectModel;
        }


        public async Task<Project?> DeleteAsync(int id)
        {
            var projectModel = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);

            if(projectModel == null) return null;

            _context.Projects.Remove(projectModel);
            await _context.SaveChangesAsync();

            return projectModel;
        }

        public async Task<List<Project>> GetAllAsync()
        {
            var projects = _context.Projects.Include(b => b.Books);
            return await projects.ToListAsync();
        }

        public async Task<Project?> GetByIdAsync(int id)
        {
            return await _context.Projects.Include(b => b.Books).FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<bool> ProjectExists(int id)
        {
            return _context.Projects.AnyAsync(p => p.Id == id);
        }

        public async Task<Project?> UpdateAsync(int id, UpdateProjectDto projectDto)
        {
            var existingProject = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);

            if(existingProject == null) return null;

            existingProject.Title = projectDto.Title;

            await _context.SaveChangesAsync();
            return existingProject;

        }

        
    }
}