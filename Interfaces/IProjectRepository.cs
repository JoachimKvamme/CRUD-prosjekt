using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_prosjekt.Dto.Project;
using CRUD_prosjekt.Models;

namespace CRUD_prosjekt.Interfaces
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
        Task<Project?> GetByIdAsync(int id);
        Task<Project> CreateAsync(Project projectModel);
        Task<Project?> UpdateAsync(int id, UpdateProjectDto projectDto);
        Task<Project?> DeleteAsync(int id);
        Task<bool> ProjectExists(int id); 

    }
}